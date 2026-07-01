<!--岗位管理 he -->
<template>
  <div class="app-container">
    <el-card shadow="always"> 
      <div>
         <vxe-grid ref='xGrid' 
          size="small" 
          auto-resize        
          v-bind="gridOptions"
          :row-style="rowStyle"    
          :footer-method="footerMethod"  
                
          @cell-dblclick="cellDBLClickEvent">          
          <template v-slot:history="{ row }">
            <vxe-button icon="fa fa-history" title="查看历史数据" circle @@click="showHistoryEvent(row)"></vxe-button>                
          </template>
        </vxe-grid>

        <vxe-modal v-model="showDetails" title="查看详情" width="600" height="400" :mask="false" :lock-view="false" resize>
          <template v-slot>
            <vxe-table border="inner"
              auto-resize
              show-overflow
              highlight-hover-row
              height="auto"
              :show-header="false"
              :sync-resize="showDetails"
              :data="detailData">
              <vxe-table-column field="label" width="40%"></vxe-table-column>
              <vxe-table-column field="value"></vxe-table-column>
            </vxe-table>
          </template>
        </vxe-modal>
      </div>
    </el-card>   
  </div>
</template>

<script lang="ts">
  import {
  ref,  
  toRefs,
  reactive,
  onMounted,
  getCurrentInstance,
  onUnmounted,
} from "vue"; 
 
import EditModule from "./component/editModule.vue";
import XEAjax from 'xe-ajax';
import {	
  getUrlKey,
	getUrlParam,
} from '/@/utils/myTools';



//这里需要从env中读取
const baseUrl= "https://www.zhjtypt.com/wldevice/"; //如果同一域名，那可以用'../'


//在下面函数中，this.$refs.xGrid可以得到表格对象。

//表格的列信息：key是列名，value是中文名，这里统一命名，后面可以多次使用
var columnName = { //注意，左边是字段名，右边是显示的中文标题
  DeviceFacId: "设备编号",
  Name: "设备名称",
  ProjectCode: "所属项目",
  FactoryCode: "厂家",
  Department: "标段",
  Longitude: "经度",
  Latitude: "纬度",
  Memo: "备注"          
};


const project = getUrlParam("projectCode");

export default {
  name: "index",    
  data() {  //这里不能用setup()为什么？setup用于同步场景？  
    return {
      showDetails: false,//刚开始不显示详情
      gridOptions: {
        border: true,
        resizable: true,
        showHeaderOverflow: true,
        showOverflow: true,
        highlightHoverRow: true,
        keepSource: true,
        id: 'full_edit_1',
        //height: 500,//固定值，会导致页面挣脱了外层框架
        rowId: 'Id', //特别注意：如果后台返回的数据没有id字段，那么前台会自动添加id字段，所以这里应该是后台返回 字段
        showFooter: true,//显示表尾统计

        customConfig: {
          storage: true, //是否启用 localStorage 本地保存，会将列操作状态保留在本地（需要有 id）
          //自定义列是否允许列选中的方法，该方法的返回值用来决定这一列的 checkbox 是否可以选中
          checkMethod: this.checkColumnMethod
        },
        printConfig: {
          columns: [
            { field: 'DeviceFacId' },
            { field: 'Name' },
            { field: 'ProjectCode' },
            { field: 'FactoryCode' },
            { field: 'Department' },
            { field: 'Longitude' },
            { field: 'Latitude' },                               
            { field: 'Memo' }
          ]
        },
        sortConfig: {
          trigger: 'cell' //（点击表头触发）
        },
        filterConfig: {
          remote: true //改变会调用服务端
        },
        pagerConfig: { 
          //layouts 可以不设置，默认和下面的有点不同
          layouts: ['PrevJump', 'PrevPage', 'JumpNumber', 'NextPage', 'NextJump', 'Sizes', 'FullJump', 'PageCount', 'Total'],
          pageSize: 10,
          pageSizes: [5, 10, 15, 20, 50, 100, 200, 500, 1000]
        },
        formConfig: {
          titleWidth: 100,
          titleAlign: 'right',
          items: [
            //folding: true 折叠起来
            { field: 'DeviceFacId', title: columnName['DeviceFacId'], span: 4, itemRender: { name: '$input', props: { placeholder: '请输入设备编号' } } },
            { field: 'Name', title: columnName['Name'], span: 4, itemRender: { name: '$input', props: { placeholder: '请输入设备名称' } } },
            { field: 'ProjectCode', title: columnName['ProjectCode'], span: 4, itemRender: { name: '$input', props: { placeholder: '请输入所属项目' } } },
            { field: 'FactoryCode', title: columnName['FactoryCode'], span: 4, itemRender: { name: '$input', props: { placeholder: '请输入厂家' } } },
            { field: 'Department', title: columnName['Department'], span: 4,  itemRender: { name: '$input', props: { placeholder: '请输入标段' } } },
            { field: 'Longitude', title: columnName['Longitude'], span: 4, folding: true, itemRender: { name: '$input', props: { placeholder: '请输入经度' } } },
            { field: 'Latitude', title: columnName['Latitude'], span: 4, folding: true, itemRender: { name: '$input', props: { placeholder: '请输入纬度' } } },
            { field: 'Memo', title: columnName['Memo'], span: 4, folding: true, itemRender: { name: '$input', props: { placeholder: '请输入备注' } } },
            //{ field: 'birth', title: '出生日期', span: 4, folding: true, itemRender: { name: '$input', props: { type: 'datetime', placeholder: '请输入日期' } } },
            { span: 24, align: 'center', collapseNode: true, itemRender: { name: '$buttons', children: [{ props: { type: 'submit', content: '查询', status: 'primary' } }, { props: { type: 'reset', content: '重置' } }] } }
          ]
        },
        toolbarConfig: {
          buttons: [
            { code: 'insert_actived', name: '新增', icon: 'fa fa-plus', visible: true },
            { code: 'delete', name: '直接删除', icon: 'fa fa-trash-o' },
            { code: 'mark_cancel', name: '删除/取消', icon: 'fa fa-trash-o' },
            { code: 'save', name: '保存', icon: 'fa fa-save', status: 'success' }
          ],
          refresh: true,
          //导入导出
          //import: true,
          //export: true,
          print: true,
          zoom: true,
          custom: true
        },
        proxyConfig: {
            seq: true, // 启用动态序号代理
            sort: true, // 启用排序代理
            filter: true, // 启用筛选代理
            form: true, // 启用表单代理
            props: {
              result: 'result',
              total: 'page.total'
            },
            ajax: {
              // 接收 Promise 对象
              query: ({ page, sorts, filters, form }) => {
                //this.$refs.xGrid.maximize()//不要最大化
                //显示加载中
                this.loading = true
                //获取表单的参数
                const queryParams = Object.assign({}, form)
                //如果有页面URL传来的参数，那么这里可以当做查询参数传入
                
                if (project != null && project != '')
                  queryParams['projectCode'] = project;
                // 处理排序条件
                const firstSort = sorts[0]
                if (firstSort) {
                  queryParams.sort = firstSort.property
                  queryParams.order = firstSort.order
                }
                // 处理筛选条件（即表头上的下拉选择）
                filters.forEach(({ property, values }) => {
                    queryParams[property] = values.join(',')
                })
                //return XEAjax.get(`https://api.xuliangzhan.com:10443/api/pub/page/list/${page.pageSize}/${page.currentPage}`, queryParams)
                //return XEAjax.get(`../JiaoBanZhuang_Device/GetVueTableData?rows=${page.pageSize}&page=${page.currentPage}`, queryParams)
                return XEAjax.get(baseUrl + `/JiaoBanZhuang_Device/GetVueTableData?rows=${page.pageSize}&page=${page.currentPage}`, queryParams)                
              },
              delete: ({ body }) => {
                if (body != 'undefined') {
                  var list = body.removeRecords;
                  if (list != null && list != 'undefined')
                    //XEAjax.post('../JiaoBanZhuang_Device/Delete', list)
                    XEAjax.post(baseUrl + `/JiaoBanZhuang_Device/Delete`, list)
                  else
                    ;
                }
              },
              //add he update 都在这里
              save: ({ body }) => {
                //做修改
                if (body != 'undefined') {
                  if (body.updateRecords.length > 0) {
                    var list = body.updateRecords;
                    if (list != null && list != 'undefined')
                      //XEAjax.post(`../JiaoBanZhuang_Device/Update`, list)
                      XEAjax.post(baseUrl + `/JiaoBanZhuang_Device/Update`, list)
                  }
                  //有可能同时做插入和修改
                  if (body.insertRecords.length > 0) {
                    var list = body.insertRecords;
                    if (list != null && list != 'undefined')
                      //XEAjax.post(`../JiaoBanZhuang_Device/Add`, list)
                      XEAjax.post(baseUrl + `/JiaoBanZhuang_Device/Add`, list)
                  }
                  //有可能前台做删除标记
                  if (body.pendingRecords.length > 0) {
                    var list = body.pendingRecords;
                    if (list != null && list != 'undefined')
                      //XEAjax.post(`../JiaoBanZhuang_Device/Delete`, list)
                      XEAjax.post(baseUrl + `/JiaoBanZhuang_Device/Delete`, list)
                  }

                }
              },
              //这个目前没加按钮
              add: ({ body }) => {
                if (body != 'undefined') {
                  var list = body.insertRecords;
                  if (list != null && list != 'undefined')
                      //XEAjax.post(`../JiaoBanZhuang_Device/Add`, list)
                    XEAjax.post(baseUrl + `/JiaoBanZhuang_Device/Add`, list)
                  else
                    ;
                }
              }
                //save: ({ body }) => XEAjax.post('https://api.xuliangzhan.com:10443/api/pub/save', body)
            }
        },
        columns: [
            //{ type: 'checkbox', title: 'Id', width: 120 },
          { type: 'checkbox', width: 50 },
          { type: 'seq', width: 60 },
          //下面去掉 editRender: { name: 'input' }就不能编辑
          { field: 'DeviceFacId', title: columnName['DeviceFacId'], sortable: true, editRender: { name: 'input' } },
          { field: 'Name', title: columnName['Name'], sortable: true, editRender: { name: 'input' } },
          { field: 'ProjectCode', title: columnName['ProjectCode'], editRender: { name: 'input' } },
          { field: 'FactoryCode', title: columnName['FactoryCode'], editRender: { name: 'input' } },
          { field: 'Department', title: columnName['Department'], editRender: { name: 'input' } },
          { field: 'Longitude', title: columnName['Longitude'], visible: true, sortable: true, editRender: { name: '$input' } },
          
          // { field: 'birth', title: '出生日期', visible: true, sortable: true, formatter: this.formatDate, editRender: { name: '$input', props: { type: 'datetime' } } },
          { field: 'Latitude', title: columnName['Latitude'], sortable: true, editRender: { name: 'input' } },
          { field: 'Memo', title: columnName['Memo'], sortable: true, editRender: { name: 'input' } },
                                      //{ field: 'createDate', title: 'Create Date', width: 160, visible: false, sortable: true, formatter: this.formatDate },
          //{ title: '实时数据', width: 60, slots: { default: 'operate' } },
          { title: '历史数据', width: 60, slots: { default: 'history' } }

        ],
        importConfig: {
          remote: true,
          importMethod: this.importMethod,
          types: ['xlsx'],
          modes: ['insert']
        },
        exportConfig: {
          remote: true,//是否服务端导出
          exportMethod: this.exportMethod, //只对服务端导出有效
          //xlsx在前端导出还是有问题，目前只能后端导出xlsx
          types: ['xlsx'],//['csv', 'html','txt','xml']
          modes: ['current', 'selected', 'all']
        },
        checkboxConfig: {
          //labelField: 'id', //是否checkbox旁边显示id编号
          reserve: true,
          highlight: true,
          range: true
        },
        /* //这里在现在的框架下会出错
        editRules: {//表头上显示星号(required),及其他限制
          name: [
            { required: true, message: '名称必须填写' },
            { min: 3, max: 50, message: '名称长度在 3 到 50 个字符' }
          ],
          email: [
            { required: true, message: '邮件必须填写' }
          ],
          role: [
            { required: true, message: '角色必须填写' }
          ]
        }, */
        
        editConfig: {
          trigger: 'click',
          mode: 'row',
          showStatus: true
        },
      }
    }
  },
  created() {
    //this.$refs.xGrid.revert();
      //这个时候this.$refs.xGrid为null：this.$refs.xGrid.maximize()失效
      //this.findSexList()
      this.loading = false
      //下面代码放哪里更合适？
      /* var tool = new MyTool();
      var right = tool.getUrlParam('right');
      //if (right != null)
      this.initRight(right)

      //下句：获取页面传来的参数，用于后面查找query
      this.project = tool.getUrlParam('project');
*/
      //下面的定时刷新数据，如果不需要定时刷新可以注释掉
      //setInterval(() => {
      //    this.$refs.xGrid.commitProxy('query');
      //    this.loading = false
      //}, 60000) //毫秒
  },
  
  methods: {
    initRight(right) {
        //alert(right) 三个逗号隔开的4个数：依次表示查增改删，1表示可见，0或者没有表示不可见。例如：1,0,0,1
        // searchBtn, addBtn, editBtn, deleteBtn
        /*  if (right != null) {
            var ops = right.split(',');
            if (!(ops[0] == '1')) {
                //这里最后一个item为查询和重置按钮
                var items = this.gridOptions.formConfig.items;
                if (items != 'undifined' && items.length > 0)
                    items[items.length - 1].visible = false;
            }
            if (!(ops[1] == '1')) {
                this.gridOptions.toolbarConfig.buttons[0].visible = false;
            }
            if (!(ops[3] == '1')) {
                this.gridOptions.toolbarConfig.buttons[1].visible = false;
                this.gridOptions.toolbarConfig.buttons[2].visible = false;
            }
            if (!(ops[2] == '1')) {
                this.gridOptions.toolbarConfig.buttons[3].visible = false;
            }

            //this.gridOptions.toolbarConfig.buttons[0].visible = false;
            //this.gridOptions.toolbarConfig.buttons[1].visible = false;
            //this.gridOptions.toolbarConfig.buttons[2].visible = false;
            //this.gridOptions.toolbarConfig.buttons[3].visible = false;
            //this.gridOptions.editConfig = null;
            //不能修改和新增的时候，点击表格不能进入编辑状态
            if (!(ops[1] == '1') && !(ops[2] == '1')) {
                this.gridOptions.editConfig = null;
            }
        } */
    },

    //钱格式（加$）
    formatAmount({ cellValue }) {
      return cellValue ? `$${XEUtils.commafy(XEUtils.toNumber(cellValue), { digits: 2 })}` : ''
    },
    //日期格式
    formatDate({ cellValue }) {
      return XEUtils.toDateString(cellValue, 'yyyy-MM-dd HH:ss:mm')
    },
    //表格的自定义显示列中必选的列，如果没有，下面就空着
    checkColumnMethod({ column }) {
      //if (['nickname', 'role'].includes(column.property)) {
      //    return false
      //}
      return true
    },
    cellDBLClickEvent({ row }) {
        //下面是vxe-grid的方式：直接前台提供数据显示
      this.detailData = ['DeviceFacId', 'Name', 'ProjectCode', 'FactoryCode', 'Department', 'Longitude', 'Latitude', 'Memo'].map(field => {
        return {
            label: this.$refs.xGrid.getColumnByField(field).title, value: row[field]
        }
      })
      this.showDetails = true

        //下面是旧的方式，需要调用后台
        //var url1 = 'DetailDataPanel?id=' + row['id'];
        //var content1 = '<iframe src="' + url1 + '"  frameborder="no" border="0" "></iframe>';
        //layer.tab({ //这个是tab层
        //    area: ['1000px', '700px'],
        //    tab: [
        //        {
        //            title: '发送单位详情',
        //            content: content1
        //        }
        //    ]
        //});
    },
    //cellClickEvent({ row }) {
    //    this.detailData = ['name', 'nickname', 'role', 'sex', 'age', 'amount'].map(field => {
    //        return { label: field, value: row[field] }
    //    })
    //    this.showDetails = true
    //},
    
    showHistoryEvent(row) {
        //这里切换到历史数据页面：
      self.location.href = "https://www.gdjtypt.com/device/JiaoBanZhuang_stat/Index?device_key=" + row['DeviceFacId']

    },
    importMethod({ file }) {
      // 处理表单
      const formBody = new FormData()
      formBody.append('file', file) //传到后台的文件
      formBody.append('picPath', "testv")//传到后台的参数
      // 上传文件
      //return XEAjax.post('https://api.xuliangzhan.com:10443/api/pub/import',
      return XEAjax.post('http://localhost:4498/Sender/import', formBody).then(data => {
          // this.$refs.XModal 也有问题
          this.$XModal.message({ message: `成功导入 ${data.result.insertRows} 条记录！`, status: 'success' })
          // 导入完成，刷新表格
          this.$refs.xGrid.commitProxy('query')
      }).catch(() => {
          this.$XModal.message({ message: '导入失败，请检查数据是否正确！', status: 'error' })
      })
    },
    exportMethod({ options }) { //提示：options里有当前页的数据，导出当前页的时候可以传递到后台。
      const proxyInfo = this.$refs.xGrid.getProxyInfo()
      // 传给服务端的参数
      const body = { //如果要导出所有页的数据（当前查询条件），那么需要把表单的数据也传递过去
        filename: options.filename,
        sheetName: options.sheetName,
        isHeader: options.isHeader,
        original: options.original,
        mode: options.mode,
        pager: proxyInfo.pager,
        ids: options.mode === 'selected' ? options.data.map(item => item.id) : [],
        fields: options.columns.map(column => {
            return {
                field: column.property,
                title: column.title
            }
        })
      }

      //1)这是一种导出方法，完全在服务器端生成
      var url = "ExportData?body=" + $.param(body);
      window.open(url); //导出并打开

      // 开始服务端导出：应该是分2步：1.先服务端生成xlsx文件存在服务器硬盘
      //2.调用并下载（服务端应该删除）
      //return XEAjax.post('https://api.xuliangzhan.com:10443/api/pub/export', body).then(data => {
      //    //return XEAjax.post('https://api.xuliangzhan.com:10443/api/pub/export', body).then(data => {
      //    //这里返回的data内容为：
      //    //id: 1612882826220
      //    //name: "导出_源_20210209225924.xlsx"
      //    //time: 1612882826220
      //    if (data.id) {
      //        this.$XModal.message({ message: '导出成功，开始下载', status: 'success' })
      //        // 读取路径，请求文件
      //        XEAjax.fetch(`https://api.xuliangzhan.com:10443/api/pub/export/download/${data.id}`).then(response => {
      //            response.blob().then(blob => {
      //                // 开始下载
      //                this.$XSaveFile({ filename: '导出数据', type: 'xlsx', content: blob })
      //            })
      //        })
      //    }
      //}).catch(() => {
      //    this.$XModal.message({ message: '导出失败！', status: 'error' })
      //})
    },

    //行颜色设置（后台传过来一个字段Color的值例如：'red'
    rowStyle({ row, rowIndex }) {
      if (row.Color != null && row.Color != 'undefined' && row.Color != '' && row.Color != "black") {
        return {
          backgroundColor: row.Color, //背景色
          //color: '#ffffff' //字体 白色
        }
      }
    },

    //表尾统计（这里目前是前台的统计，如果需要（分页）后台统计，那么参考例子调用后台
    footerMethod({ columns, data }) {
      return [
        columns.map((column, columnIndex) => {
          if (columnIndex === 0) {
              return '和值'
          }
          if (['age', 'amount'].includes(column.property)) {
              return XEUtils.sum(data, column.property)
          }
          return null
        }),
        columns.map((column, columnIndex) => {
          if (columnIndex === 0) {
              return '平均'
          }
          if (['age', 'amount'].includes(column.property)) {
              return XEUtils.mean(data, column.property)
          }
          return null
        })
      ]
    }
  } 
};

</script>
