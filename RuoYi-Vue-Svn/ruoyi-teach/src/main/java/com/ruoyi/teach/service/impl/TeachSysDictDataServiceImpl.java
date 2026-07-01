package com.ruoyi.teach.service.impl;

import com.ruoyi.teach.domain.entity.TeachSysDictData;
import com.ruoyi.teach.mapper.TeachSysDictDataMapper;
import com.ruoyi.teach.service.ITeachSysDictDataService;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
@RequiredArgsConstructor
public class TeachSysDictDataServiceImpl implements ITeachSysDictDataService {

    private final TeachSysDictDataMapper teachSysDictDataMapper;

    @Override
    public List<TeachSysDictData> selectDictDataByType(String dictType) {
        return teachSysDictDataMapper.selectDictDataByType(dictType);
    }
}
