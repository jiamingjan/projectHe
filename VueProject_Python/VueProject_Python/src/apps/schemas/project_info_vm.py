"""
此文件定义了 系统岗位 相关的数据模型。
"""
from decimal import Decimal

from apps.schemas.common import *

class ProjectInfoResp(BaseResponse):
    """
    跌倒设备响应模型
    """
    Id: Optional[int] = Field(default=None, alias='Id', description="项目ID")
    PrjName: Optional[str] = Field(default=None, alias='PrjName', description="项目名称")
    PrjCode: Optional[str] = Field(default=None, alias='PrjCode', description="项目编号")
    PrjType: Optional[int] = Field(default=None, alias='PrjType', description="项目类型")
    PrjDesc: Optional[str] = Field(default=None, alias='PrjDesc', description="项目描述")
    PrjStatus: Optional[str] = Field(default=None, alias='PrjStatus', description="项目状态")
    StartDate: Optional[datetime] = Field(default=None, alias='StartDate', description="开始日期")
    EndDate: Optional[datetime] = Field(default=None, alias='EndDate', description="结束日期")
    Manager: Optional[str] = Field(default=None, alias='Manager', description="项目经理")
    Money: Optional[Decimal] = Field(default=None, alias='Money', description="项目资金")
    CreateBy: Optional[str] = Field(default=None, alias='CreateBy', description="创建者")
    CreateTime: Optional[datetime] = Field(default=None, alias='CreateTime', description="创建时间")
    UpdateBy: Optional[str] = Field(default=None, alias='UpdateBy', description="更新者")
    UpdateTime: Optional[datetime] = Field(default=None, alias='UpdateTime', description="更新时间")
    DeleteTime: Optional[datetime] = Field(default=None, alias='DeleteTime', description="删除时间")
    Remark: Optional[str] = Field(default=None, alias='Remark', description="备注")
