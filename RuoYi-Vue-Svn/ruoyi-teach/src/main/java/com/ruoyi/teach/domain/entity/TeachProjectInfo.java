package com.ruoyi.teach.domain.entity;

import lombok.Data;

import java.io.Serializable;

import java.util.Date;

@Data
public class TeachProjectInfo implements Serializable {

    private Integer id;

    private String prjName;

    private String prjCode;

    private Long prjType;

    private String prjStatus;

    private String prjDesc;

    private Date startDate;

    private Date endDate;

    private String manager;

    private Integer money;

    private String remark;

    private String createBy;

    private String updateBy;

    private Date createTime;

    private Date updateTime;

    private Date deleteTime;

}
