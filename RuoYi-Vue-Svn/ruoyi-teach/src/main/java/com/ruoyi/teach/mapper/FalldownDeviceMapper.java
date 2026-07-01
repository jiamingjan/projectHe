package com.ruoyi.teach.mapper;


import com.ruoyi.teach.domain.entity.FalldownDevice;
import org.apache.ibatis.annotations.Mapper;
import org.apache.ibatis.annotations.Param;

import java.util.List;

@Mapper
public interface FalldownDeviceMapper {

    List<FalldownDevice> findByConditions(
            @Param("deviceCode") String deviceCode,
            @Param("model") String model,
            @Param("status") String status,
            @Param("pageNum") Integer pageNum,
            @Param("pageSize") Integer pageSize
    );

    FalldownDevice findById(@Param("id") Long id);

    int addFalldownDevice(FalldownDevice falldownDevice);

    int updateFalldownDevice(FalldownDevice falldownDevice);

    int deleteFalldownDevice(@Param("id") Long id);

}




