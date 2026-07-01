package com.ruoyi.teach.domain.entity;

import lombok.Data;

import java.util.Date;
import java.util.List;

@Data
public class TeachUser {

    private Long userId;

    private String nickName;

    private String phone;

    private Integer roleId;

    private String salt;

    private String avatar;

    private String sex;

    private String email;

    private Integer deptId;

    private Integer postId;

    private String createBy;

    private String updateBy;

    private String remark;

    private String status;

    private Date createTime;

    private Date updateTime;

    private Date deleteTime;

    private String username;

    private String password;

    private List<Long> roleIds;

    private List<Long> postIds;

}
