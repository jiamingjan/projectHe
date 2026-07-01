import request from '/@/utils/request';

// 查询岗位列表
export function listFalldownDevice(query:any) {
	return request({
		url: '/device/falldowndevice/list',
		method: 'get',
		params: query
	})
}

// 查询岗位详细
export function getFalldownDevice(Id:number) {
	return request({
		url: '/device/falldowndevice/detail?Id=' + Id,
		method: 'get'
	})
}

// 新增岗位
export function addFalldownDevice(data:any) {
	return request({
		url: '/device/falldowndevice/add',
		method: 'post',
		data: data
	})
}

// 修改岗位
export function updateFalldownDevice(data:any) {
	return request({
		url: '/device/falldowndevice/update',
		method: 'post',
		data: data
	})
}

// 删除岗位
export function delFalldownDevice(Id: string) {
	return request({
		url: '/device/falldowndevice/delete',
		method: 'post',
		data: Id
	})
}