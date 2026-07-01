package com.ruoyi.teach.service;

import com.ruoyi.teach.domain.entity.FalldownDevice;

import java.util.List;

public interface IFalldownDeviceService {

    List<FalldownDevice> findByConditions(
            String deviceCode,
            String model,
            String status,
            Integer pageNum,
            Integer pageSize
    );

    FalldownDevice findById(Long id);

    int addFalldownDevice(FalldownDevice falldownDevice);

    int updateFalldownDevice(FalldownDevice falldownDevice);

    int deleteFalldownDevice(Long id);

}
