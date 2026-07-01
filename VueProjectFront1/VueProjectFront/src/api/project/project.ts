import request from '/@/utils/request';

// 查询项目列表
export function listProject(query: any) {
    return request({
        url: '/ProjectInfo/list',
        method: 'get',
        params: query
    })
}

// 查询项目详细
export function getProject(Id: number) {
    return request({
        url: '/ProjectInfo/detail?Id=' + Id,
        method: 'get'
    })
}

// 新增项目
export function addProject(data: any) {
    return request({
        url: '/ProjectInfo/add',
        method: 'post',
        data: data
    })
}

// 修改项目
export function updateProject(data: any) {
    return request({
        url: '/ProjectInfo/update',
        method: 'post',
        data: data
    })
}

// 删除项目
export function delProject(ids: any) {
    return request({
        url: '/ProjectInfo/delete',
        method: 'post',
        data: ids
    })
}