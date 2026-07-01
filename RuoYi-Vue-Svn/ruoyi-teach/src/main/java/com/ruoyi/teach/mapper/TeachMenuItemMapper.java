package com.ruoyi.teach.mapper;

import com.ruoyi.teach.domain.entity.TeachMenuItem;
import org.apache.ibatis.annotations.Mapper;
import org.apache.ibatis.annotations.Param;

import java.util.Collection;
import java.util.List;

@Mapper
public interface TeachMenuItemMapper {

    List<TeachMenuItem> selectByMenuIds(@Param("menuIds") Collection<Long> menuIds);

}
