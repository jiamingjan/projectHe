<!--岗位管理 he -->
<template>
  <div class="app-container">
    <el-card shadow="always"> 

    <div>
    <vxe-grid ref='xGrid'
              v-bind="gridOptions"
              :row-style="rowStyle" 
              
              @cell-dblclick="cellDBLClickEvent">
      
        <template v-slot:operate="{ row }">
                <vxe-button @click="showStatusEvent(row)">实时</vxe-button>
                <vxe-button icon="fa fa-line-chart" title="查看曲线" circle @click="showChartEvent(row)"></vxe-button>
            </template>
        <template v-slot:history="{ row }">
            <vxe-button icon="fa fa-history" title="查看历史数据" circle @click="showHistoryEvent(row)"></vxe-button>
    
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

//这里需要从env中读取
const baseUrl= "https://www.gdjtypt.com/MyDevice/";
export default {
  name: "index",   
  data() {    
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
        height: 700,
        rowId: 'Id', //特别注意：如果后台返回的数据没有id字段，那么前台会自动添加id字段，所以这里应该是后台返回 字段
        showFooter: true,//显示表尾统计

        customConfig: {
            storage: true, //是否启用 localStorage 本地保存，会将列操作状态保留在本地（需要有 id）
            //自定义列是否允许列选中的方法，该方法的返回值用来决定这一列的 checkbox 是否可以选中
            checkMethod: this.checkColumnMethod
        },
        printConfig: {
            columns: [
                { field: 'DeviceId' },
                { field: 'Model' },
                { field: 'ProductId' },
                { field: 'IMEI' },
                { field: 'AppId' },
                { field: 'AppName' },
                { field: 'ProjectCode' },
                { field: 'Department' },
                { field: 'Status' }
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
                { field: 'DeviceId', title: '设备编号', span: 4, itemRender: { name: '$input', props: { placeholder: '请输入设备编号' } } },
                { field: 'Model', title: '设备型号', span: 4, itemRender: { name: '$input', props: { placeholder: '请输入设备型号' } } },
                { field: 'ProductId', title: '平台产品ID', span: 4, itemRender: { name: '$input', props: { placeholder: '请输入平台产品ID' } } },
                { field: 'IMEI', title: 'IMEI', span: 4, itemRender: { name: '$input', props: { placeholder: '请输入IMEI' } } },
                { field: 'AppId', title: '平台应用ID', span: 4, folding: false, itemRender: { name: '$input', props: { placeholder: '请输入平台应用ID' } } },
                { field: 'AppName', title: '平台项目名称', span: 4, folding: true, itemRender: { name: '$input', props: { placeholder: '请输入平台项目名称' } } },
                { field: 'ProjectCode', title: '项目名称', span: 4, folding: true, itemRender: { name: '$input', props: { placeholder: '请输入项目名称' } } },
                { field: 'Department', title: '标段', span: 4, folding: true, itemRender: { name: '$input', props: { placeholder: '请输入标段' } } },
                { field: 'Status', title: '设备状态', span: 4, folding: true, itemRender: { name: '$input', props: { placeholder: '请输入状态' } } },
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
                        this.$refs.xGrid.maximize()//最大化表格，放哪里最合适？有些地方xGrid为null
                        //显示加载中
                        this.loading = true
                        //获取表单的参数
                        const queryParams = Object.assign({}, form)
                        //如果有页面传来的参数，那么这里可以当做查询参数传入
                        if (this.project != null && this.project != '')
                            queryParams['project'] = this.project;
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
                        //return XEAjax.get(`../ElectricityDevice/GetVueTableData?rows=${page.pageSize}&page=${page.currentPage}`, queryParams)
                        return XEAjax.get(baseUrl + `/ElectricityDevice/GetVueTableData?rows=${page.pageSize}&page=${page.currentPage}`, queryParams)
                    },
                    delete: ({ body }) => {
                        if (body != 'undefined') {
                            var list = body.removeRecords;
                            if (list != null && list != 'undefined')
                                XEAjax.post('../ElectricityDevice/Delete', list)
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
                                    XEAjax.post(`../ElectricityDevice/Update`, list)
                            }
                            //有可能同时做插入和修改
                            if (body.insertRecords.length > 0) {
                                var list = body.insertRecords;
                                if (list != null && list != 'undefined')
                                    XEAjax.post(`../ElectricityDevice/Add`, list)
                            }
                            //有可能前台做删除标记
                            if (body.pendingRecords.length > 0) {
                                var list = body.pendingRecords;
                                if (list != null && list != 'undefined')
                                    //XEAjax.post(`../ElectricityDevice/Delete`, list)
                                    XEAjax.post(baseUrl + `/ElectricityDevice/Delete`, list)
                            }

                        }
                    },
                    //这个目前没加按钮
                    add: ({ body }) => {
                        if (body != 'undefined') {
                            var list = body.insertRecords;
                            if (list != null && list != 'undefined')
                                //XEAjax.post(`../ElectricityDevice/Add`, list)
                                XEAjax.post(baseUrl + `/ElectricityDevice/Add`, list)
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
                { field: 'DeviceId', title: '设备编号', sortable: true, editRender: { name: 'input' } },
                { field: 'Model', title: '设备型号', sortable: true, editRender: { name: 'input' } },
                { field: 'ProductId', title: '平台产品ID', editRender: { name: 'input' } },
                { field: 'IMEI', title: 'IMEI', editRender: { name: 'input' } },
                { field: 'AppId', title: '平台应用ID', editRender: { name: 'input' } },
                { field: 'AppName', title: '平台项目名称', visible: true, sortable: true, editRender: { name: '$input' } },
                // { field: 'amount', title: '数量', formatter: this.formatAmount, editRender: { name: '$input', props: { type: 'float', digits: 2 } } },
                // { field: 'birth', title: '出生日期', visible: true, sortable: true, formatter: this.formatDate, editRender: { name: '$input', props: { type: 'datetime' } } },
                { field: 'ProjectCode', title: '项目名称', sortable: true, editRender: { name: 'input' } },
                { field: 'Status', title: '设备状态', sortable: true, editRender: { name: 'input' } },
                { field: 'Department', title: '标段', sortable: true, editRender: { name: 'input' } },
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
            },
            editConfig: {
                trigger: 'click',
                mode: 'row',
                showStatus: true
            },

        }

    }
  },
  created() {
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
          this.detailData = ['name', 'nickname', 'role', 'sex', 'age', 'birth', 'amount'].map(field => {
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
      showStatusEvent(row) {
          //这里切换到实时数据页面：
          self.location.href = "../ElectricityStatus/DetailDataPanel"
          var eTool = new ElectricityTool();
          var colNames = eTool.getColumnNameArray();
          var qry = '';
          for (var i = 0; i < colNames.length; i++) {
              //下面需要添加css,让按钮好看一些
              qry = qry + '&' + colNames[i] + '=' + 0;
          }
          self.location.href = '../ElectricityStatus/DetailDataPanel?DeviceId=' + row['DeviceId'] + '&Id=' + row['Id'] + '&Timestamp=' + row['Timestamp']
              + '&DeviceStatus=' + row['DeviceStatus'] + '&SignalPower=' + row['SignalPower'] + qry;
          //下面是旧的方式，显示图表
          //var url1 = 'EditDataPanel?id=' + row['id'];
          //var content1 = '<iframe src="' + url1 + '"  frameborder="no" border="0" "></iframe>';
          //layer.tab({ //这个是tab层
          //    area: ['1000px', '700px'],
          //    tab: [
          //        {
          //            title: '编辑',
          //            content: content1
          //        }
          //    ]
          //});
      },
      showHistoryEvent(row) {
          //这里切换到历史数据页面：
          self.location.href = "../ElectricityStatus/Index?DeviceId=" + row['DeviceId']

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
/*
  setup() {
     const tableData = ref([
      { id: 10001, name: 'Test1', role: 'Develop', sex: 'Man', address: 'Shenzhen' },
      { id: 10002, name: 'Test2', role: 'Test', sex: 'Man', address: 'Guangzhou' },
      { id: 10003, name: 'Test3', role: 'PM', sex: 'Man', address: 'Shanghai' }
    ]);

    
    return {
      tableData,
     
    };*/
  };

</script>
