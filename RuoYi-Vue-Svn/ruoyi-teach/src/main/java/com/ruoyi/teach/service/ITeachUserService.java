package com.ruoyi.teach.service;

import com.ruoyi.teach.domain.entity.TeachUser;

public interface ITeachUserService {

    TeachUser login(String username, String password, String captcha, String uuid);

}
