package com.ruoyi.teach.controller;

import com.google.code.kaptcha.Producer;
import com.ruoyi.common.constant.CacheConstants;
import com.ruoyi.common.constant.Constants;
import com.ruoyi.common.core.domain.AjaxResult;
import com.ruoyi.common.core.redis.RedisCache;
import com.ruoyi.common.utils.sign.Base64;
import com.ruoyi.common.utils.uuid.IdUtils;
import com.ruoyi.framework.web.service.TokenService;
import com.ruoyi.teach.domain.dto.bo.TeachLoginBo;
import com.ruoyi.teach.domain.dto.vo.TeachLoginVo;
import com.ruoyi.teach.domain.entity.TeachUser;
import com.ruoyi.teach.service.ITeachMenuService;
import com.ruoyi.teach.service.ITeachUserService;
import lombok.SneakyThrows;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.util.FastByteArrayOutputStream;
import org.springframework.web.bind.annotation.*;

import javax.annotation.Resource;
import javax.imageio.ImageIO;
import java.awt.image.BufferedImage;
import java.io.IOException;
import java.util.concurrent.TimeUnit;

@RequestMapping("/system/user")
@RestController
public class LoginController {

    @Resource(name = "captchaProducer")
    private Producer captchaProducer;

    @Autowired
    TokenService tokenService;

    @Autowired
    private RedisCache redisCache;

    @Autowired
    private ITeachUserService teachUserService;

    @Autowired
    private ITeachMenuService teachMenuService;

    @GetMapping("/getCaptcha")
    public AjaxResult getCaptcha() {
        AjaxResult ajax = AjaxResult.success();

        // 保存验证码信息
        String uuid = IdUtils.simpleUUID();
        String verifyKey = CacheConstants.CAPTCHA_CODE_KEY + uuid;

        String capStr = null, code = null;
        BufferedImage image = null;

        // 生成验证码
        capStr = code = captchaProducer.createText();
        image = captchaProducer.createImage(capStr);

        redisCache.setCacheObject(verifyKey, code, Constants.CAPTCHA_EXPIRATION, TimeUnit.MINUTES);
        // 转换流信息写出
        FastByteArrayOutputStream os = new FastByteArrayOutputStream();
        try
        {
            ImageIO.write(image, "jpg", os);
        }
        catch (IOException e)
        {
            return AjaxResult.error(e.getMessage());
        }

        ajax.put("captchaId", uuid);
        ajax.put("base64Captcha", "data:image/gif;base64," + Base64.encode(os.toByteArray()));
        return ajax;
    }

    @SneakyThrows
    @PostMapping("/login")
    public Object userLogin(@RequestBody TeachLoginBo loginBo) {

        TeachUser login = teachUserService.login(
                loginBo.getUsername(),
                loginBo.getPassword(),
                loginBo.getCaptcha(),
                loginBo.getCaptchaId()
        );

        if (login == null) {
            return AjaxResult.error(401, "用户名或密码错误");
        }

        String token = tokenService.createToken(login.getUserId());

        TeachLoginVo teachLoginVo = teachMenuService.selectTeachLoginInfoByRoleIds(login.getRoleIds());
        teachLoginVo.setUser(login);
        teachLoginVo.setToken(token);

        return AjaxResult.success(teachLoginVo);
    }

}
