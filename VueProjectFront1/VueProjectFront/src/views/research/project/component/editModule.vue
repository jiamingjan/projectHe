<template>
  <div class="system-menu-container">
    <el-dialog v-model="isShowDialog" width="860px">
      <template #title>
        <div style="font-size: large" v-drag="['.system-menu-container .el-dialog', '.system-menu-container .el-dialog__header']">{{title}}</div>
      </template>
      <el-form
        :model="ruleForm"
        size="small"
        :rules="ruleRules"
        ref="ruleFormRef"
        label-width="100px"
      >
        <el-row :gutter="35">
          <el-col :span="12" class="mb20">
            <el-form-item label="项目名称" prop="PrjName">
              <el-input
                v-model="ruleForm.PrjName"
                placeholder="请输入项目名称"
              />
            </el-form-item>
          </el-col>
          <el-col :span="12" class="mb20">
            <el-form-item label="项目编号" prop="PrjCode">
              <el-input
                v-model="ruleForm.PrjCode"
                placeholder="请输入项目编号"
              />
            </el-form-item>
          </el-col>

          <el-col :span="12" class="mb20">
            <el-form-item label="项目类型" prop="PrjType">
              <el-input
                v-model="ruleForm.PrjType"
                placeholder="请输入项目类型"
              />
            </el-form-item>
          </el-col>
          <el-col :span="12" class="mb20">
            <el-form-item label="项目状态" prop="PrjStatus">
              <el-radio-group v-model="ruleForm.PrjStatus">
                <el-radio label="正常">正常</el-radio>
                <el-radio label="禁用">禁用</el-radio>
              </el-radio-group>
            </el-form-item>
          </el-col>

          <el-col :span="12" class="mb20">
            <el-form-item label="开始日期" prop="StartDate">
              <el-date-picker
                v-model="ruleForm.StartDate"
                type="datetime"
                placeholder="选择开始日期"
              />
            </el-form-item>
          </el-col>
          <el-col :span="12" class="mb20">
            <el-form-item label="结束日期" prop="EndDate">
              <el-date-picker
                v-model="ruleForm.EndDate"
                type="datetime"
                placeholder="选择结束日期"
              />
            </el-form-item>
          </el-col>

          <el-col :span="12" class="mb20">
            <el-form-item label="项目经理" prop="Manager">
              <el-input
                v-model="ruleForm.Manager"
                placeholder="请输入项目经理"
              />
            </el-form-item>
          </el-col>
          <el-col :span="12" class="mb20">
            <el-form-item label="项目金额" prop="Money">
              <el-input
                v-model="ruleForm.Money"
                placeholder="请输入项目金额"
              />
            </el-form-item>
          </el-col>

          <el-col :span="24" class="mb20">
            <el-form-item label="项目描述" prop="PrjDesc">
              <el-input
                v-model="ruleForm.PrjDesc"
                type="textarea"
                rows="3"
                placeholder="请输入项目描述"
              />
            </el-form-item>
          </el-col>
          <el-col :span="24" class="mb20">
            <el-form-item label="备注" prop="Remark">
              <el-input
                v-model="ruleForm.Remark"
                type="textarea"
                rows="3"
                placeholder="请输入备注信息"
              />
            </el-form-item>
          </el-col>
        </el-row>
      </el-form>
      <template #footer>
        <span class="dialog-footer">
          <el-button @click="onCancel" size="small">取 消</el-button>
          <el-button type="primary" @click="onSubmit" size="small">保 存</el-button>
        </span>
      </template>
    </el-dialog>
  </div>
</template>

<script lang="ts">
import { reactive, toRefs, ref, unref, getCurrentInstance } from "vue";
import { updateProject, addProject } from "/@/api/project/project";
import { ElMessage } from "element-plus";

export default {
  name: "editProject",
  props: {
    title: {
      type: String,
      default: () => "",
    },
  },
  setup() {
    const { proxy } = getCurrentInstance() as any;
    const ruleFormRef = ref<HTMLElement | null>(null);
    const state = reactive({
      isShowDialog: false,
      ruleForm: {
        Id: 0,
        PrjName: "",
        PrjCode: "",
        PrjType: undefined,
        PrjStatus: "正常",
        PrjDesc: "",
        StartDate: undefined,
        EndDate: undefined,
        Manager: "",
        Money: undefined,
        Remark: ""
      },
      ruleRules: {
        PrjName: [
          { required: true, message: "项目名称不能为空", trigger: "blur" }
        ],
        PrjCode: [
          { required: true, message: "项目编号不能为空", trigger: "blur" }
        ]
      },
    });

    const openDialog = (row: any) => {
      if (row.Id && row.Id != 0) {
        state.ruleForm = { ...row };
      } else {
        initForm();
      }
      state.isShowDialog = true;
    };

    const closeDialog = (row?: object) => {
      proxy.mittBus.emit("onEditProjectModule", row);
      state.isShowDialog = false;
    };

    const onCancel = () => {
      closeDialog();
    };

    const onSubmit = () => {
      const formWrap = unref(ruleFormRef) as any;
      if (!formWrap) return;
      formWrap.validate((valid: boolean) => {
        if (valid) {
          if (state.ruleForm.Id && state.ruleForm.Id !== 0) {
            updateProject(state.ruleForm).then(() => {
              ElMessage.success("修改成功");
              closeDialog(state.ruleForm);
            });
          } else {
            addProject(state.ruleForm).then(() => {
              ElMessage.success("新增成功");
              closeDialog(state.ruleForm);
            });
          }
        }
      });
    };

    const initForm = () => {
      state.ruleForm = {
        Id: 0,
        PrjName: "",
        PrjCode: "",
        PrjType: undefined,
        PrjStatus: "正常",
        PrjDesc: "",
        StartDate: undefined,
        EndDate: undefined,
        Manager: "",
        Money: undefined,
        Remark: ""
      };
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