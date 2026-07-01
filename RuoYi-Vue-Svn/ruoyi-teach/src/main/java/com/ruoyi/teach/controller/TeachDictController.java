package com.ruoyi.teach.controller;


import com.ruoyi.common.core.controller.BaseController;
import com.ruoyi.common.core.domain.AjaxResult;
import com.ruoyi.teach.service.ITeachSysDictDataService;
import lombok.RequiredArgsConstructor;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

@RequestMapping("/system/dict")
@RestController
@RequiredArgsConstructor
public class TeachDictController extends BaseController {

    private final ITeachSysDictDataService teachSysDictDataService;

    @GetMapping("/data/type")
    public AjaxResult getDictDataByType(@RequestParam("dictType") String dictType) {
        return success(teachSysDictDataService.selectDictDataByType(dictType));
    }

}
