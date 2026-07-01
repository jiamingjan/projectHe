<template>
  <div class="app-container">
    <el-card shadow="always">
    <!-- 查询表单 -->
    <el-form
      :model="queryParams"
      ref="queryForm"
      :inline="true"
      label-width="80px"
    >
      <el-form-item label="项目名称" prop="prjName">
        <el-input
          placeholder="请输入项目名称"
          clearable
          size="small"
          @keyup.enter="handleQuery"
          style="width: 240px"
          v-model="queryParams.prjName"
        />
      </el-form-item>
      <el-form-item label="项目编号" prop="prjCode">
        <el-input
          placeholder="请输入项目编号"
          clearable
          size="small"
          @keyup.enter="handleQuery"
          style="width: 240px"
          v-model="queryParams.prjCode"
        />
      </el-form-item>
      <el-form-item label="项目经理" prop="manager">
        <el-input
          placeholder="请输入项目经理"
          clearable
          size="small"
          @keyup.enter="handleQuery"
          style="width: 240px"
          v-model="queryParams.manager"
        />
      </el-form-item>
      <el-form-item label="项目状态" prop="prjStatus">
        <el-select
          v-model="queryParams.prjStatus"
          placeholder="请选择状态"
          clearable
          size="small"
          style="width: 240px"
        >
          <el-option label="正常" value="正常" />
          <el-option label="禁用" value="禁用" />
        </el-select>
      </el-form-item>
      <el-form-item>
        <el-button type="primary" icon="el-icon-search" size="mini" @click="handleQuery">搜索</el-button>
        <el-button icon="el-icon-refresh" size="mini" @click="resetQuery">重置</el-button>
      </el-form-item>
    </el-form>

    <!-- 操作按钮 -->
    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button type="primary" plain icon="el-icon-plus" size="mini" @click="onOpenAddModule">新增</el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" plain icon="el-icon-delete" size="mini" :disabled="multiple" @click="onTabelRowDel">删除</el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="el-icon-download" size="mini" @click="handleExport">导出</el-button>
      </el-col>
    </el-row>

    <!-- 数据表格 -->
    <el-table
      v-loading="loading"
      :data="tableData"
      @selection-change="handleSelectionChange"
    >
      <el-table-column type="selection" width="55" align="center" />
      <el-table-column label="项目ID" align="center" prop="Id" />
      <el-table-column label="项目名称" align="center" prop="PrjName" />
      <el-table-column label="项目编号" align="center" prop="PrjCode" />
      <el-table-column label="项目类型" align="center" prop="PrjType" />
      <el-table-column label="项目经理" align="center" prop="Manager" />
      <el-table-column label="项目金额" align="center" prop="Money" />
      <el-table-column
        label="项目状态"
        align="center"
        prop="PrjStatus"
      >
        <template #default="scope">
          <el-tag :type="scope.row.PrjStatus === '正常' ? 'success' : 'danger'">
            {{ scope.row.PrjStatus }}
          </el-tag>
        </template>
      </el-table-column>
      <el-table-column label="操作" align="center">
        <template #default="scope">
          <el-button size="mini" type="text" icon="el-icon-edit" @click="onOpenEditModule(scope.row)">修改</el-button>
          <el-button size="mini" type="text" icon="el-icon-delete" @click="onTabelRowDel(scope.row)">删除</el-button>
        </template>
      </el-table-column>
    </el-table>

    <!-- 分页 -->
    <div v-show="total > 0" style="margin-top:15px">
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

    <EditModule ref="editModuleRef" :title="title" />
  </div>
</template>

<script lang="ts">
import { ref, toRefs, reactive, onMounted, getCurrentInstance, onUnmounted } from "vue";
import { ElMessageBox, ElMessage } from "element-plus";
import { listProject, delProject } from "/@/api/project/project";
import EditModule from "./component/editModule.vue";

export default {
  name: "ProjectIndex",
  components: { EditModule },
  setup() {
    const { proxy } = getCurrentInstance() as any;
    const editModuleRef = ref();
    const state = reactive({
      loading: true,
      ids: [],
      single: true,
      multiple: true,
      title: "",
      tableData: [],
      total: 0,
      queryParams: {
        pageNum: 1,
        pageSize: 10,
        prjName: undefined,
        prjCode: undefined,
        manager: undefined,
        prjStatus: undefined
      }
    });

    // 查询列表
    const handleQuery = () => {
      state.loading = true;
      listProject(state.queryParams).then((response:any) => {
        state.tableData = response.data.data;
        state.total = response.data.total;
        state.loading = false;
      });
    };

    // 重置
    const resetQuery = () => {
      state.queryParams = {
        pageNum: 1,
        pageSize: 10,
        prjName: undefined,
        prjCode: undefined,
        manager: undefined,
        prjStatus: undefined
      };
      handleQuery();
    };

    // 分页
    const handleCurrentChange = (val:number) => {
      state.queryParams.pageNum = val;
      handleQuery();
    };
    const handleSizeChange = (val:number) => {
      state.queryParams.pageSize = val;
      handleQuery();
    };

    // 弹窗
    const onOpenAddModule = () => {
      state.title = "新增项目";
      editModuleRef.value.openDialog([]);
    };
    const onOpenEditModule = (row: any) => {
      state.title = "修改项目";
      editModuleRef.value.openDialog(row);
    };

    // ✅ 已修复：批量删除 + 单个删除（和例子完全一致）
    const onTabelRowDel = (row?: any) => {
      var Ids = row?.Id || state.ids;
      var msg = "";
      
      if(state.ids.length == 0) {
        Ids = [row.Id];
        msg = '是否确认删除项目编号为"' + row.PrjCode + '"的数据项?';
      } else {
        msg = '是否确认删除'+Ids.length+'行数据?';
      }
        
      ElMessageBox({
        message: msg,
        title: "警告",
        showCancelButton: true,
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning",
      }).then(function () {
        return delProject(Ids).then(() => {
          handleQuery();
          ElMessage.success("删除成功");
        });
      });
    };

    // 导出
    const handleExport = () => {
      proxy.downloadFile('/ProjectInfo/export', { ...state.queryParams }, `project_${new Date().getTime()}.xlsx`);
    };

    // 多选
    const handleSelectionChange = (selection: any) => {
      state.ids = selection.map((item:any) => item.Id);
      state.single = selection.length !== 1;
      state.multiple = !selection.length;
    };

    onMounted(() => {
      handleQuery();
      proxy.mittBus.on("onEditProjectModule", handleQuery);
    });
    onUnmounted(() => {
      proxy.mittBus.off("onEditProjectModule");
    });

    return {
      editModuleRef,
      handleQuery,
      resetQuery,
      handleCurrentChange,
      handleSizeChange,
      onOpenAddModule,
      onOpenEditModule,
      onTabelRowDel,
      handleExport,
      handleSelectionChange,
      ...toRefs(state)
    };
  },
};
</script>