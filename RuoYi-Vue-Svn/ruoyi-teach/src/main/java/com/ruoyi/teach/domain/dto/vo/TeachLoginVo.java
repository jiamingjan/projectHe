package com.ruoyi.teach.domain.dto.vo;

import com.ruoyi.teach.domain.entity.TeachUser;
import com.ruoyi.teach.domain.model.TeachMenu;
import lombok.Data;

import java.util.Collection;
import java.util.List;

@Data
public class TeachLoginVo {

    private Long expire;

    private List<TeachMenu> menus;

    private Collection<String> permissions;

    private String token;

    private TeachUser user;

}
