package com.ruoyi.teach.domain.entity;


import java.io.Serializable;

import java.util.Date;
import lombok.Data;


@Data
public class TeachMenuItem implements Serializable {

    private Long menuId;

    private String menuName;

    private String title;

    private Integer parentId;

    private Integer sort;

    private String icon;

    private String path;

    private String component;

    private String isFrame;

    private String isLink;

    private String menuType;

    private String isHide;

    private String isKeepAlive;

    private String isAffix;

    private String permission;

    private String status;

    private String createBy;

    private String updateBy;

    private String remark;

    private Date createTime;

    private Date updateTime;

    private Date deleteTime;

}
