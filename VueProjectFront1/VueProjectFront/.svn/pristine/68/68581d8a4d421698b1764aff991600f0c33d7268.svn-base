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
      <el-form-item label="设备编码" prop="DeviceCode">
        <el-input
          placeholder="请输入设备编码模糊查询"
          clearable
          size="small"
          @keyup.enter="handleQuery"
          style="width: 240px"
          v-model="queryParams.DeviceCode"
        />
      </el-form-item>
      <el-form-item label="设备型号" prop="Model">
        <el-input
          placeholder="请输入设备型号模糊查询"
          clearable
          size="small"
          @keyup.enter="handleQuery"
          style="width: 240px"
          v-model="queryParams.Model"
        />
      </el-form-item>
      <el-form-item label="状态" prop="Status">
        <el-select
          v-model="queryParams.Status"
          placeholder="状态"
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
          v-auth="'device:falldowndevice:add'"
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
          v-auth="'device:falldowndevice:delete'"
          :disabled="multiple"
          @click="onTabelRowDel"
          >删除</el-button
        >
      </el-col>
      <el-col :span="1.5">
        <el-button
          type="warning"
          plain
          icon="el-icon-download"
          size="mini"
          v-auth="'device:falldowndevice:export'"
          @click="onTabelRowDel"
          >导出</el-button
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
      <el-table-column label="设备编号" align="center" prop="DeviceCode" />
      <el-table-column label="设备型号" align="center" prop="Model" />
      <el-table-column label="家属电话" align="center" prop="ContactPhones" />
      <el-table-column label="设备电话" align="center" prop="Phone" />
      <el-table-column
        label="状态"
        align="center"
        prop="Status"
      >
        <template #default="scope">
          <el-tag
                  :type="scope.row.Status === '1' ? 'danger' : 'success'"
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
            v-auth="'device:falldowndevice:edit'"
            @click="onOpenEditModule(scope.row)"
            >修改</el-button
          >
          <el-button
            v-if="scope.row.parentId != 0"
            size="mini"
            type="text"
            icon="el-icon-delete"
            v-auth="'device:falldowndevice:delete'"
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
import { listFalldownDevice, delFalldownDevice } from "/@/api/device/falldowndevice";
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
        DeviceCode: undefined,
        Model: undefined,
        Status: undefined,
      },
    });

    /** 查询岗位列表 */
    const handleQuery = () => {
      state.loading = true;
      listFalldownDevice(state.queryParams).then((response) => {
        state.tableData = response.data.data;
        state.total = response.data.total;
        state.loading = false;
      });
    };
    /** 重置按钮操作 */
    const resetQuery = () => {
      state.queryParams.DeviceCode = undefined;
      state.queryParams.Model = undefined;
      state.queryParams.Status = undefined;
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
      return proxy.selectDictLabel(state.statusOptions, row.Status);
    };

    // 打开新增报警器弹窗
    const onOpenAddModule = (row: object) => {
      row = [];
      state.title = "添加报警器";
      editModuleRef.value.openDialog(row);
    };
    // 打开编辑报警器弹窗
    const onOpenEditModule = (row: object) => {
      state.title = "修改报警器";
      editModuleRef.value.openDialog(row);
    };
    /** 删除按钮操作 */
    const onTabelRowDel = (row: any) => {
      const Ids = row.Id || state.ids;
      ElMessageBox({
        message: '是否确认删除报警器编号为"' + Ids + '"的数据项?',
        title: "警告",
        showCancelButton: true,
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning",
      }).then(function () {
        return delFalldownDevice(Ids).then(() => {
          handleQuery();
          ElMessage.success("删除成功");
        });
      });
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
