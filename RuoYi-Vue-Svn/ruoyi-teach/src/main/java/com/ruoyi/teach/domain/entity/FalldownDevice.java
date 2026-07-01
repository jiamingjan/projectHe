package com.ruoyi.teach.domain.entity;

import java.util.Date;

import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.Data;

@Data
public class FalldownDevice {
    @JsonProperty("Id")
    private Long id;

    @JsonProperty("DeviceCode")
    private String deviceCode;

    @JsonProperty("Status")
    private String status;

    @JsonProperty("Model")
    private String model;

    @JsonProperty("DeviceName")
    private String contactPhones;

    @JsonProperty("Phone")
    private String phone;

    @JsonProperty("Flag")
    private String flag;

    @JsonProperty("CreateBy")
    private String createBy;

    @JsonProperty("UpdateBy")
    private String updateBy;

    @JsonProperty("Remark")
    private String remark;

    @JsonProperty("CreateTime")
    private Date createTime;

    @JsonProperty("UpdateTime")
    private Date updateTime;

    @JsonProperty("DeleteTime")
    private Date deleteTime;
}