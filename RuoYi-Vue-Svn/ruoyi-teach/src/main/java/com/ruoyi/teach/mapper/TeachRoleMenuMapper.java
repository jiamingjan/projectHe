package com.ruoyi.teach.mapper;

import com.ruoyi.teach.domain.entity.TeachRoleMenu;
import org.apache.ibatis.annotations.Mapper;
import org.apache.ibatis.annotations.Param;

import java.util.Collection;
import java.util.List;

@Mapper
public interface TeachRoleMenuMapper {

    List<TeachRoleMenu> selectTeachRoleMenuListByRoleId(Long roleId);

    List<TeachRoleMenu> selectTeachRoleMenuListByRoleIds(@Param("roleIds") Collection<Long> roleIds);

}
