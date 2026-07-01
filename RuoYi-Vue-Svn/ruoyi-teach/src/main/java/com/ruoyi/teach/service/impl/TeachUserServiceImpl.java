package com.ruoyi.teach.service.impl;

import com.ruoyi.common.constant.CacheConstants;
import com.ruoyi.common.core.redis.RedisCache;
import com.ruoyi.common.utils.StringUtils;
import com.ruoyi.teach.domain.entity.TeachUser;
import com.ruoyi.teach.mapper.TeachUserMapper;
import com.ruoyi.teach.service.ITeachUserService;
import org.apache.commons.codec.digest.DigestUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.stereotype.Service;

import java.util.Objects;

@Service
public class TeachUserServiceImpl implements ITeachUserService {

    @Autowired
    private TeachUserMapper teachUserMapper;


    @Autowired
    private RedisCache redisCache;

    @Override
    public TeachUser login(String username, String password, String captcha, String uuid) {

        String verifyKey = CacheConstants.CAPTCHA_CODE_KEY + StringUtils.nvl(uuid, "");
        String result = redisCache.getCacheObject(verifyKey);
        redisCache.deleteObject(verifyKey);


        if (!StringUtils.equalsIgnoreCase(captcha, result)) {
            throw new RuntimeException("验证码错误");
        }

        if (StringUtils.isEmpty(username) || StringUtils.isEmpty(password)) {
            throw new RuntimeException("用户名或密码不能为空");
        }

        TeachUser teachUser = Objects.requireNonNull(
                teachUserMapper.selectTeachUserByUserName(username),
                "用户不存在"
        );

        if (StringUtils.equalsIgnoreCase(
                DigestUtils.md5Hex(password),
                teachUser.getPassword()
        )) {
            UsernamePasswordAuthenticationToken authentication = new UsernamePasswordAuthenticationToken(teachUser, null);
            SecurityContextHolder.getContext().setAuthentication(authentication);
            return teachUser;
        }
        throw new RuntimeException("密码错误");
    }
}
