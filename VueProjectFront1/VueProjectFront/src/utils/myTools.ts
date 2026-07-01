/**
 * 2021.12 helm add
 * 我自己增加的工具类集合
 * 
 */

/**
 * 获取url参数，不支持base64
 * @param name 输入的key，url输入的url字符串
 * @returns 返回结果字符串
 */
export function getUrlKey(name: string,url: string){
　　return decodeURIComponent((new RegExp('[?|&]' + name + '=' + '([^&;]+?)(&|#|;|$)').exec(url) || [, ""])[1].replace(/\+/g, '%20')) || null	
}

/**
 * 获取url参数，不支持base64
 * @param name 输入的key
 * @returns 返回结果字符串
 */
export function getUrlParam (name: string){	
	let url = window.location.search; //有时候search为空
	if(url == null || url == '')
		url = window.location.href;
	return decodeURIComponent((new RegExp('[?|&]' + name + '=' + '([^&;]+?)(&|#|;|$)').exec(url) || [, ""])[1].replace(/\+/g, '%20')) || null
}

