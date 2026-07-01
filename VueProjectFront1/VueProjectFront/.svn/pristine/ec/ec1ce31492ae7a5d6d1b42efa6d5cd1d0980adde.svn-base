import request from '/@/utils/request';


// 查询用户列表
export function listUser(query: Array<object>) {
	return request({
		url: '/system/user/list',
		method: 'get',
		params: query
	})
}

// 用户状态修改
export function changeUserStatus(userId: number, status: string) {
	const data = {
		userId,
		status
	}
	return request({
		url: '/system/user/changeStatus',
		method: 'put',
		data: data
	})
}

// 查询用户详细
//modify by helm
export function getUser(userId: number) {
	return request({
		url: '/system/user/getById?userId=' + userId,
		method: 'get',		
	})
}
/* export function getUser(userId: number) {
	return request({
		url: '/system/user/getById/' + userId,
		method: 'get'
	})
}
 */
// 添加时查询用户详细
export function getUserInit() {
	return request({
		url: '/system/user/getInit',
		method: 'get'
	})
}

// 添加时查询用户ROLE POST
export function getRoPo() {
	return request({
		url: '/system/user/getRoPo',
		method: 'get'
	})
}
// 删除用户
//下面对应的后台路由不好弄，改成post
 export function delUser(userId: number) {
	return request({
		//url: '/system/user/' + userId, //old
		url: '/system/user/delete', 
		method: 'post', //原来是delete 改成 post
		data: userId
	})
}  

/*  export function delUser(userId: number) {
	return request({
		url: '/system/user/' + userId, //old		
		method: 'delete', //原来是delete 改成 post		
	})
} 
 */
// 新增用户
export function addUser(data: any) {
	return request({
		url: '/system/user/add', //modif by helm 
		//url: '/system/user/', //old 
		method: 'post',
		data: data
	})
}

// 修改用户
export function updateUser(data:any) {
	return request({
		//url: '/system/user',//old 
		url: '/system/user/update', //modif by helm 
		method: 'put',
		data: data
	})
}

// 修改密码
export function updateUserPwd(data:any) {
	return request({
		url: '/system/user/pwd',
		method: 'put',
		data: data
	})
}


// 导出
export function exportUser(query: any) {
	return request({
		url: '/system/user/export',
		method: 'get',
		params: query
	})
}

// 下载用户导入模板
export function importTemplate() {
	return request({
		url: '/system/user/importTemplate',
		method: 'get'
	})
}

// 用户头像上传
export function uploadAvatar(data:any) {
	return request({
		url: '/system/user/avatar',
		method: 'post',
		data: data
	})
}