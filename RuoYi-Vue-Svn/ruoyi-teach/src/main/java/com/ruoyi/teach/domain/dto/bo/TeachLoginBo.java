package com.ruoyi.teach.domain.dto.bo;

import lombok.Data;

@Data
public class TeachLoginBo {

    private String captcha;

    private String captchaId;

    private String password;

    private String username;

}
