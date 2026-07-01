package com.ruoyi.teach.service;

import com.ruoyi.teach.domain.entity.TeachSysDictData;

import java.util.List;

public interface ITeachSysDictDataService {

    List<TeachSysDictData> selectDictDataByType(String dictType);

}
