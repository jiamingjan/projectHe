package com.ruoyi.teach.mapper;

import com.ruoyi.teach.domain.entity.TeachSysDictData;
import org.apache.ibatis.annotations.Mapper;

import java.util.List;

@Mapper
public interface TeachSysDictDataMapper {

    List<TeachSysDictData> selectDictDataByType(String dictType);

}




