package com.ruoyi.teach.domain.entity;

import java.util.Date;
import lombok.Data;

@Data
public class TeachSysDictData {
    private Long dictCode;

    private Integer dictSort;

    private String dictLabel;

    private String dictValue;

    private String dictType;

    private String status;

    private String cssClass;

    private String listClass;

    private String isDefault;

    private String createBy;

    private String updateBy;

    private String remark;

    private Date createTime;

    private Date updateTime;

    private Date deleteTime;
}