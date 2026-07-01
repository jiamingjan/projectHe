package com.ruoyi.teach.domain.entity;


import java.io.Serializable;

import lombok.Data;

@Data
public class TeachRoleMenu implements Serializable {

    private Long id;

    private Integer roleId;

    private Integer menuId;

    private String roleName;

}
