package com.ruoyi.teach.domain.entity;

import java.math.BigDecimal;
import java.util.Date;

import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.Data;

@Data
public class Project {
    @JsonProperty("Id")
    private Long id;

    @JsonProperty("PrjName")
    private String prjName;

    @JsonProperty("PrjCode")
    private String prjCode;

    @JsonProperty("PrjType")
    private Long prjType;

    @JsonProperty("PrjStatus")
    private String prjStatus;

    @JsonProperty("PrjDesc")
    private String prjDesc;

    @JsonProperty("StartDate")
    private Date startDate;

    @JsonProperty("EndDate")
    private Date endDate;

    @JsonProperty("Manager")
    private String manager;

    @JsonProperty("Money")
    private BigDecimal money;

    @JsonProperty("Remark")
    private String remark;

    @JsonProperty("CreateBy")
    private String createBy;

    @JsonProperty("UpdateBy")
    private String updateBy;

    @JsonProperty("CreateTime")
    private Date createTime;

    @JsonProperty("UpdateTime")
    private Date updateTime;

    @JsonProperty("DeleteTime")
    private Date deleteTime;
}