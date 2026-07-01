package com.ruoyi.common.core.controller;


import com.github.pagehelper.PageInfo;
import com.ruoyi.common.core.domain.AjaxResult;
import com.ruoyi.common.core.page.PagedResult;

import java.util.List;

public class TeachBaseController extends BaseController {

    protected AjaxResult getPagedData(
            List<?> list,
            int pageNum,
            int pageSize
    ) {
        PagedResult<?> pagedResult = new PagedResult<>(list, new PageInfo(list).getTotal());
        pagedResult.setPageSize(pageSize);
        pagedResult.setPageNum(pageNum);
        return success(pagedResult);
    }

}
