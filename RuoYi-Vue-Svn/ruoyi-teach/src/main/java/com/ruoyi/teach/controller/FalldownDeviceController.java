package com.ruoyi.teach.controller;

import com.ruoyi.common.core.controller.TeachBaseController;
import com.ruoyi.common.core.domain.AjaxResult;
import com.ruoyi.teach.domain.entity.FalldownDevice;
import com.ruoyi.teach.service.IFalldownDeviceService;
import lombok.RequiredArgsConstructor;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequiredArgsConstructor
@RequestMapping("/device/falldowndevice")
public class FalldownDeviceController extends TeachBaseController {

    private final IFalldownDeviceService falldownDeviceService;

    @GetMapping("/list")
    public AjaxResult list(
            @RequestParam(value = "DeviceCode", required = false) String deviceCode,
            @RequestParam(value = "Model", required = false) String model,
            @RequestParam(value = "Status", required = false) String status,
            @RequestParam(value = "pageNum", required = false) Integer pageNum,
            @RequestParam(value = "pageSize", required = false) Integer pageSize
    ) {
        startPage(pageNum, pageSize);
        return getPagedData(
                falldownDeviceService.findByConditions(deviceCode, model, status, pageNum, pageSize),
                pageNum,
                pageSize
        );
    }

    @GetMapping("/detail")
    public AjaxResult detail(
            @RequestParam(value = "Id") Long id
    ) {
        return success(falldownDeviceService.findById(id));
    }

    @PostMapping("/add")
    public AjaxResult add(
            @RequestBody FalldownDevice falldownDevice
    ) {
        return success(falldownDeviceService.addFalldownDevice(falldownDevice));
    }

    @PostMapping("/update")
    public AjaxResult update(
            @RequestBody FalldownDevice falldownDevice
    ) {
        return success(falldownDeviceService.updateFalldownDevice(falldownDevice));
    }

    @PostMapping("/delete")
    public AjaxResult delete(
            @RequestBody Long id
    ) {
        return success(falldownDeviceService.deleteFalldownDevice(id));
    }

}
