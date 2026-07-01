<!--报警器设备管理 he -->
<template>
  <div class="app-container">
    <el-card shadow="always">
    <!-- 查询 -->
    <el-form
      :model="queryParams"
      ref="queryForm"
      :inline="true"
      label-width="68px"
    >
      <el-form-item label="项目名称" prop="PrjName">
        <el-input
          placeholder="请输入项目名称查询"
          clearable
          size="small"
          @keyup.enter="handleQuery"
          style="width: 240px"
          v-model="queryParams.prjName"
        />
      </el-form-item>
      <el-form-item label="项目编号" prop="PrjCode">
        <el-input
          placeholder="请输入项目编号查询"
          clearable
          size="small"
          @keyup.enter="handleQuery"
          style="width: 240px"
          v-model="queryParams.prjCode"
        />
      </el-form-item>
      <el-form-item label="项目经理" prop="Manager">
        <el-input
          placeholder="请输入项目经理查询"
          clearable
          size="small"
          @keyup.enter="handleQuery"
          style="width: 240px"
          v-model="queryParams.manager"
        />
      </el-form-item>
      <el-form-item label="项目状态" prop="PrjStatus">
        <el-select
          v-model="queryParams.prjStatus"
          placeholder="项目状态"
          clearable
          size="small"
          style="width: 240px"
        >
          <el-option
            v-for="dict in statusOptions"
            :key="dict.dictValue"
            :label="dict.dictLabel"
            :value="dict.dictValue"
          />
        </el-select>
      </el-form-item>
      <el-form-item>
        <el-button
          type="primary"
          icon="el-icon-search"
          size="mini"
          @click="handleQuery"
          >搜索</el-button
        >
        <el-button icon="el-icon-refresh" size="mini" @click="resetQuery"
          >重置</el-button
        >
      </el-form-item>
    </el-form>

    <!-- 操作按钮 -->
    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button
          type="primary"
          plain
          icon="el-icon-plus"
          size="mini"
          
          @click="onOpenAddModule"
          >新增</el-button
        >
      </el-col>
      <el-col :span="1.5">
        <el-button
          type="danger"
          plain
          icon="el-icon-delete"
          size="mini"
          
          :disabled="multiple"
          @click="onTabelRowDel"
          >删除</el-button
        >
      </el-col>
    </el-row>

    <!--数据表格-->
    <el-table
      v-loading="loading"
      :data="tableData"
      @selection-change="handleSelectionChange"
    >
      <el-table-column type="selection" width="55" align="center" />
      <el-table-column label="项目名称" align="center" prop="PrjName" />
      <el-table-column label="项目编号" align="center" prop="PrjCode" />
      <el-table-column label="项目类型" align="center" prop="PrjType" />
      <el-table-column label="项目描述" align="center" prop="PrjDesc" />
      <el-table-column label="开始时间" align="center" prop="StartDate" />
      <el-table-column label="结束时间" align="center" prop="EndDate" />
      <el-table-column label="项目经理" align="center" prop="Manager" />
      <el-table-column label="项目经费" align="center" prop="Money" />
      <el-table-column
        label="项目状态"
        align="center"
        prop="PrjStatus"
      >
        <template #default="scope">
          <el-tag
                  :type="scope.row.PrjStatus === '正常' ? 'success' : 'danger'"
                  disable-transitions
          >{{ statusFormat(scope.row)}}</el-tag>
        </template>
      </el-table-column>
      <el-table-column
        label="操作"
        align="center"
        class-name="small-padding fixed-width"
      >
        <template #default="scope">
          <el-button
            size="mini"
            type="text"
            icon="el-icon-edit"
            
            @click="onOpenEditModule(scope.row)"
            >修改</el-button
          >
          <el-button
            v-if="scope.row.parentId != 0"
            size="mini"
            type="text"
            icon="el-icon-delete"
           
            @click="onTabelRowDel(scope.row)"
            >删除</el-button
          >
        </template>
      </el-table-column>
    </el-table>
    <!-- 分页设置-->
    <div v-show="total > 0">
      <el-divider></el-divider>
      <el-pagination
              background
              :total="total"
              :current-page="queryParams.pageNum"
              :page-size="queryParams.pageSize"
              layout="total, sizes, prev, pager, next, jumper"
              @size-change="handleSizeChange"
              @current-change="handleCurrentChange"
      />
    </div>
    </el-card>
    <!-- 添加或修改岗位对话框 -->
    <EditModule ref="editModuleRef" :title="title" />
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
import { ElMessageBox, ElMessage } from "element-plus";
import { listProjectInfo, delProjectInfo } from "../../api/project/projectInfo.js";
import EditModule from "./component/editModule.vue";

export default {
  name: "index",
  components: { EditModule },
  setup() {
    const { proxy } = getCurrentInstance() as any;
    const editModuleRef = ref();
    const state = reactive({
      // 遮罩层
      loading: true,
      // 选中数组
      ids: [],
      // 非单个禁用
      single: true,
      // 非多个禁用
      multiple: true,
      // 弹出层标题
      title: "",
      // 岗位表格数据
      tableData: [],
      // 总条数
      total: 0,
      // 状态数据字典
      statusOptions: [],
      // 查询参数
      queryParams: {
        // 页码
        pageNum: 1,
        // 每页大小
        pageSize: 10,
        prjName: undefined,
        prjCode: undefined,
        manager: undefined,
        prjStatus: undefined,
      },
    });

    /** 查询岗位列表 */
    const handleQuery = () => {
      state.loading = true;
      listProjectInfo(state.queryParams).then((response) => {
        state.tableData = response.data.data;
        state.total = response.data.total;
        state.loading = false;
      });
    };
    /** 重置按钮操作 */
    const resetQuery = () => {
      state.queryParams.prjName = undefined;
      state.queryParams.prjCode = undefined;
      state.queryParams.manager = undefined;
      state.queryParams.prjStatus = undefined;
      handleQuery();
    };

    const handleCurrentChange = (val:number) => {
      state.queryParams.pageNum = val
      handleQuery()
    }
    const handleSizeChange = (val:number) => {
      state.queryParams.pageSize = val
      handleQuery()
    }

    const statusFormat = (row: any) => {
      return proxy.selectDictLabel(state.statusOptions, row.prjStatus);
    };

    // 打开新增报警器弹窗
    const onOpenAddModule = (row: object) => {
      row = [];
      state.title = "添加项目";
      editModuleRef.value.openDialog(row);
    };
    // 打开编辑报警器弹窗
    const onOpenEditModule = (row: object) => {
      state.title = "修改项目";
      editModuleRef.value.openDialog(row);
    };
    /** 删除按钮操作 */
    const onTabelRowDel = (row: any) => {
      var Ids = row.Id || state.ids;
      var msg = "";
      
      if(state.ids.length == 0)//如果是单个，那么需要变成数组，这样后台才能收到单个（数组里）
      {
        Ids = [row.Id];
        msg = '是否确认删除项目编号为"' + row.prjCode + '"的数据项?';
      }
      else
        msg = '是否确认删除'+Ids.length+'行数据?';
        
      ElMessageBox({
        message: msg,
        title: "警告",
        showCancelButton: true,
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning",
      }).then(function () {
        return delProjectInfo(Ids.toString()).then(() => {
          handleQuery();
          ElMessage.success("删除成功");
        });
      });
    };

    /** 导出按钮操作 */
    const handleExport = () => {
      proxy.downloadFile('/device/falldowndevice/export', {
        ...state.queryParams
      }, `falldowndevice_${new Date().getTime()}.xlsx`);
    };
    // 多选框选中数据
    const handleSelectionChange = (selection: any) => {
      state.ids = selection.map((item: any) => item.Id);
      state.single = selection.length != 1;
      state.multiple = !selection.length;
    };
    // 页面加载时
    onMounted(() => {
      // 查询报警器信息
      handleQuery();
      // 查询报警器状态数据字典
      proxy.getDicts("sys_normal_disable").then((response: any) => {
        state.statusOptions = response.data;
      });
      proxy.mittBus.on("onEditPostModule", (res: any) => {
        handleQuery();
      });
    });
    // 页面卸载时
    onUnmounted(() => {
      proxy.mittBus.off("onEditPostModule");
    });
    return {
      editModuleRef,
      handleSelectionChange,
      handleQuery,
      handleCurrentChange,
      handleSizeChange,
      resetQuery,
      statusFormat,
      onOpenAddModule,
      onOpenEditModule,
      onTabelRowDel,
      ...toRefs(state),
    };
  },
};
</script>
