"""
此文件定义了 系统岗位 相关的数据模型。
"""
from apps.schemas.common import *

class SysDictDataResp(BaseResponse):
    """
    跌倒设备响应模型
    """
    dict_code: Optional[int] = Field(default=None, alias='dict_code', description="字典编码")
    dict_sort: Optional[int] = Field(default=None, alias='dict_sort', description="排序")
    dict_label: Optional[str] = Field(default=None, alias='dict_label', description="标签")
    dict_value: Optional[str] = Field(default=None, alias='dict_value', description="值")
    dict_type: Optional[str] = Field(default=None, alias='dict_type', description="字典类型")
    css_class: Optional[str] = Field(default=None, alias='css_class', description="CssClass")
    list_class: Optional[str] = Field(default=None, alias='list_class', description="ListClass")
    is_default: Optional[str] = Field(default=None, alias='is_default', description="IsDefault")
    status: Optional[str] = Field(default=None, alias='status', description="状态（0正常 1停用）")
    CreateBy: Optional[str] = Field(default=None, alias='CreateBy', description="创建者")
    CreateTime: Optional[datetime] = Field(default=None, alias='CreateTime', description="创建时间")
    UpdateBy: Optional[str] = Field(default=None, alias='UpdateBy', description="更新者")
    UpdateTime: Optional[datetime] = Field(default=None, alias='UpdateTime', description="更新时间")
    DeleteTime: Optional[datetime] = Field(default=None, alias='DeleteTime', description="删除时间")
    Remark: Optional[str] = Field(default=None, alias='Remark', description="备注")
