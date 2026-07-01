package com.ruoyi.teach.mapper;

import com.ruoyi.teach.domain.entity.TeachUser;
import org.apache.ibatis.annotations.Mapper;

@Mapper
public interface TeachUserMapper {

    TeachUser selectTeachUserById(Long id);

    TeachUser selectTeachUserByUserName(String userName);

}
