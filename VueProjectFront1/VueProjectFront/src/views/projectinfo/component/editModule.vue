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
            <el-form-item label="项目名称" prop="PrjName">
              <el-input
                v-model="ruleForm.PrjName"
                placeholder="请输入项目名称"
                
              />
            </el-form-item>
          </el-col>
          <el-col :span="24" class="mb20">
            <el-form-item label="项目编号" prop="PrjCode">
              <el-input
                v-model="ruleForm.PrjCode"
                placeholder="请输入项目编号"
              />
            </el-form-item>
          </el-col>
          <el-col :span="24" class="mb20">
            <el-form-item label="项目类型" prop="PrjType">
              <el-input
                v-model="ruleForm.PrjType"
                placeholder="请输入项目类型"
              />
            </el-form-item>
          </el-col>
          <el-col :span="24" class="mb20">
            <el-form-item label="项目描述" prop="PrjDesc">
              <el-input
                v-model="ruleForm.PrjDesc"
                placeholder="请输入项目描述"
              />
            </el-form-item>
          </el-col>
          <el-col :span="24" class="mb20">
            <el-form-item label="开始日期" prop="StartDate">
              <el-date-picker
                v-model="ruleForm.StartDate"
                type="Day"
                value-format="YYYY-MM-DD"
                format="YYYY-MM-DD"
                placeholder="请输入开始日期"
              ></el-date-picker>
            </el-form-item>
          </el-col>
          <el-col :span="24" class="mb20">
            <el-form-item label="结束日期" prop="EndDate">
              <el-date-picker
                v-model="ruleForm.EndDate"
                type="Day"
                value-format="YYYY-MM-DD"
                format="YYYY-MM-DD"
                placeholder="请输入结束日期"
              ></el-date-picker>
            </el-form-item>
          </el-col>
          
          <el-col :span="24" class="mb20">
            <el-form-item label="项目经理" prop="Manager">
              <el-input
                v-model="ruleForm.Manager"
                placeholder="请输入项目经理"
              />
            </el-form-item>
          </el-col>
          <el-col :span="24" class="mb20">
            <el-form-item label="项目经费" prop="Money">
              <el-input
                v-model="ruleForm.Money"
                placeholder="请输入项目经费"
              />
            </el-form-item>
          </el-col>
          <el-col :span="24" class="mb20">
            <el-form-item label="项目状态" prop="PrjStatus">
              <el-radio-group v-model="ruleForm.PrjStatus">
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

      // 设备对象
      ruleForm: {
        Id: 0, // ID
        PrjName: "", //项目名称
        PrjCode: "", // 项目编号
        PrjType: 0, //项目类型
        PrjStatus: "", //项目状态
        PrjDesc: "", //项目描述
        StartDate: "", //开始日期
        EndDate: "", //结束日期
        Manager: "",// 项目经理
        Money: 0.0, //项目经费
        Remark: "", // 备注       
      },
      // 岗位状态数据字典
      statusOptions: [],
      // 岗位树选项
      deptOptions: [],
      // 表单校验
      ruleRules: {
        PrjCode: [
          { required: true, message: "项目编号不能为空", trigger: "blur" }
        ],
        PrjName: [
          { required: true, message: "项目名称不能为空", trigger: "blur" }
        ]        
      },
    });
    // 打开弹窗
    const openDialog = (row: any) => {
      if (row.Id && row.Id != undefined && row.Id != "") {
        state.ruleForm = row;
        state.ruleForm.Id=row.Id; // ID
        state.ruleForm.PrjName=row.PrjName; // 设备编码
        state.ruleForm.PrjCode=row.PrjCode;// 设备型号
        state.ruleForm.PrjType=row.PrjType;// 家属电话
        state.ruleForm.PrjStatus=row.PrjStatus;// 设备电话
        state.ruleForm.PrjDesc=row.PrjDesc; //设备状态
        state.ruleForm.StartDate=row.StartDate; //设备状态
        state.ruleForm.EndDate=row.EndDate; //设备状态
        state.ruleForm.Manager=row.Manager; //设备状态
        state.ruleForm.Money=row.Money; //设备状态
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
      state.ruleForm.Id=0; // ID
      state.ruleForm.PrjName=""; // 设备编码
      state.ruleForm.PrjCode="";// 设备型号
      state.ruleForm.PrjType=0;// 家属电话
      state.ruleForm.PrjStatus="";// 设备电话
      state.ruleForm.PrjDesc=""; //设备状态
      state.ruleForm.StartDate=""; //设备状态
      state.ruleForm.EndDate=""; //设备状态
      state.ruleForm.Manager=""; //设备状态
      state.ruleForm.Money=0.0; //设备状态
      state.ruleForm.Remark="";// 备注
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
