/* helm
系统入口，实例化Vue，加载全局对象
*/
import { createApp } from 'vue';
import App from './App.vue';
import router from './router';
import { store, key } from './store';
import { directive } from '/@/utils/directive';
import { i18n } from '/@/i18n/index';
import { globalComponentSize } from '/@/utils/componentSize';
import {addDateRange,parseTime,handleTree,selectDictLabel,download} from '/@/utils'
import { getDicts } from "/@/api/system/dict/data"
import { dateStrFormat } from "/@/utils/formatTime"

import ElementPlus from 'element-plus';
import 'element-plus/dist/index.css';
import '/@/theme/index.scss';
import mitt from 'mitt';
import screenShort from 'vue-web-screen-shot';
import VueGridLayout from 'vue-grid-layout';

//add by helm for vxe-table 2021.12.16
import 'font-awesome/scss/font-awesome.scss' //一些图标
import 'xe-utils'
//import XEAjax from 'xe-ajax'
import VXETable from 'vxe-table'
import 'vxe-table/lib/style.css'
import VXETablePluginElement from 'vxe-table-plugin-element'
import 'vxe-table-plugin-element/dist/style.css'
//VXETable.use(VXETablePluginElement);

//创建vue实例 helm
const app = createApp(App);
app
	.use(router)//启用路由 ... helm
	.use(store, key)
	.use(ElementPlus, { i18n: i18n.global.t, size: globalComponentSize })
	.use(i18n)
	.use(screenShort, { enableWebRtc: false })
	.use(VueGridLayout)
	//.use(XEAjax) //helm
	.use(VXETable) //helm
	//.use(VXETablePluginElement) //helm
	.mount('#app');

app.config.globalProperties.mittBus = mitt();

// 全局方法挂载
app.config.globalProperties.getDicts = getDicts
app.config.globalProperties.mittBus = mitt();
app.config.globalProperties.addDateRange = addDateRange;
app.config.globalProperties.parseTime = parseTime
app.config.globalProperties.handleTree = handleTree
app.config.globalProperties.selectDictLabel = selectDictLabel
app.config.globalProperties.download = download
app.config.globalProperties.dateStrFormat = dateStrFormat

//全局自定义指令的挂载 helm
directive(app);
