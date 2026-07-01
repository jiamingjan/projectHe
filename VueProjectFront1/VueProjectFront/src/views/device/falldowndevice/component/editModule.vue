<template>
  <div class="system-menu-container">
    <el-dialog v-model="isShowDialog" width="769px">
      <template #title>
        <div style="font-size: large" v-drag="['.system-menu-container .el-dialog', '.system-menu-container .el-dialog__header']">{{title}}</div>
      </template>
      <el-form
        :model="ruleForm"
        size="small"
        :rules="ruleRules"
        ref="ruleFormRef"
        label-width="80px"
      >
        <el-row :gutter="35">
          <el-col :span="24" class="mb20">
            <el-form-item label="设备型号" prop="Model">
              <el-input
                v-model="ruleForm.Model"
                placeholder="请输入设备型号"
              />
            </el-form-item>
          </el-col>
          <el-col :span="24" class="mb20">
            <el-form-item label="设备编码" prop="DeviceCode">
              <el-input
                v-model="ruleForm.DeviceCode"
                placeholder="请输入编码名称"
              />
            </el-form-item>
          </el-col>
        
          <el-col :span="24" class="mb20">
            <el-form-item label="状态" prop="Status">
              <el-radio-group v-model="ruleForm.Status">
                <el-radio
                  v-for="dict in statusOptions"
                  :key="dict.dictValue"
                  :label="dict.dictValue"
                  >{{ dict.dictLabel }}
                </el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>
          <el-col :span="24" class="mb20">
            <el-form-item label="备注" prop="Remark">
              <el-input
                v-model="ruleForm.Remark"
                type="textarea"
                placeholder="请输入内容"
              />
            </el-form-item>
          </el-col>
        </el-row>
      </el-form>
      <template #footer>
        <span class="dialog-footer">
          <el-button @click="onCancel" size="small">取 消</el-button>
          <el-button type="primary" @click="onSubmit" size="small"
            >编 辑</el-button
          >
        </span>
      </template>
    </el-dialog>
  </div>
</template>

<script lang="ts">
import { reactive, toRefs, ref, unref, getCurrentInstance } from "vue";
import { updateFalldownDevice, addFalldownDevice } from "/@/api/device/falldowndevice";
import { ElMessage } from "element-plus";

export default {
  name: "editMenu",
  props: {
    // 弹窗标题
    title: {
      type: String,
      default: () => "",
    },
  },
  setup() {
    const { proxy } = getCurrentInstance() as any;
    const ruleFormRef = ref<HTMLElement | null>(null);
    const state = reactive({
      // 是否显示弹出层
      isShowDialog: false,

      // 岗位对象
      ruleForm: {
        Id: 0, // ID
        DeviceCode: "", // 设备编码
        Model: "",// 设备型号
        ContactPhones: 0, // 家属电话
        Status: "", //设备状态
        Remark: "", // 备注       
      },
      // 岗位状态数据字典
      statusOptions: [],
      // 岗位树选项
      deptOptions: [],
      // 表单校验
      ruleRules: {
        DeviceCode: [
          { required: true, message: "设备编码不能为空", trigger: "blur" }
        ],
        Model: [
          { required: true, message: "设备型号不能为空", trigger: "blur" }
        ]        
      },
    });
    // 打开弹窗
    const openDialog = (row: any) => {
      if (row.Id && row.Id != undefined && row.Id != "") {
        state.ruleForm = row;
        state.ruleForm.Id=row.Id; // ID
        state.ruleForm.DeviceCode=row.DeviceCode; // 设备编码
        state.ruleForm.Model=row.Model;// 设备型号
        state.ruleForm.ContactPhones=row.ContactPhones;// 家属电话
        state.ruleForm.Status=row.Status; //设备状态
        state.ruleForm.Remark=row.Remark;// 备注     
      } else {
        initForm();       
      }
      state.isShowDialog = true;

      // 查询状态数据字典
      proxy.getDicts("sys_normal_disable").then((response: any) => {
        state.statusOptions = response.data;
      });    
    };

    // 关闭弹窗
    const closeDialog = (row?: object) => {     
      proxy.mittBus.emit("onEditPostModule", row);
      state.isShowDialog = false;
    };
    // 取消
    const onCancel = () => {      
      closeDialog();       
    };
    
    // 保存
    const onSubmit = () => {
      const formWrap = unref(ruleFormRef) as any;
      if (!formWrap) return;
      formWrap.validate((valid: boolean) => {
        if (valid) {
          if (
            state.ruleForm.Id != undefined &&
            state.ruleForm.Id != 0
          ) {
            updateFalldownDevice(state.ruleForm).then((response) => {
              ElMessage.success("修改成功");
              closeDialog(state.ruleForm); // 关闭弹窗
            });
          } else {
            addFalldownDevice(state.ruleForm).then((response) => {
              ElMessage.success("新增成功");
              closeDialog(state.ruleForm); // 关闭弹窗
            });
          }
        }
      });
    };
    // 表单初始化，方法：`resetFields()` 无法使用
    const initForm = () => { 
      state.ruleForm.Id = 0; // ID
      state.ruleForm.DeviceCode = ""; // 设备编码
      state.ruleForm.Model = ""; // 设备型号
      state.ruleForm.ContactPhones = 0 ; // 家属电话
      state.ruleForm.Status =  "0"; //设备状态
      state.ruleForm.Remark = ""; // 备注
    };

    return {
      ruleFormRef,
      openDialog,
      closeDialog,
      onCancel,
      initForm,
      onSubmit,
      ...toRefs(state),
    };
  },
};
</script>
