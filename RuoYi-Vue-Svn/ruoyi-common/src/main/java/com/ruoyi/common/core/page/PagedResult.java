package com.ruoyi.common.core.page;

import java.util.List;

public class PagedResult<T> {

    private Long total;

    private Integer pageSize;

    private Integer pageNum;

    private List<T> data;

    public PagedResult() {
    }

    public PagedResult(List<T> data, Long total) {
        this.data = data;
        this.total = total;
    }

    public Long getTotal() {
        return total;
    }

    public void setTotal(Long total) {
        this.total = total;
    }

    public Integer getPageSize() {
        return pageSize;
    }

    public void setPageSize(Integer pageSize) {
        this.pageSize = pageSize;
    }

    public Integer getPageNum() {
        return pageNum;
    }

    public void setPageNum(Integer pageNum) {
        this.pageNum = pageNum;
    }

    public List<T> getData() {
        return data;
    }

    public void setData(List<T> data) {
        this.data = data;
    }

}
