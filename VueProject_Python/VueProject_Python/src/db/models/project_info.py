"""
本文件定义了系统岗位表 (sys_posts) 的数据库模型。
"""
from datetime import datetime
from typing import Optional, Dict, Any
from decimal import Decimal

from sqlalchemy import BigInteger, Integer, String, DateTime, Numeric
from sqlalchemy.orm import Mapped, mapped_column
from sqlalchemy.dialects.mysql import INTEGER

from db.models.base import Base


class ProjectInfo(Base):
    """
    项目信息表 (project_info)
    """
    __tablename__ = 'project_info'
    __table_args__ = {'comment': '项目信息表'}

    # 主键
    Id: Mapped[int] = mapped_column('Id', INTEGER(unsigned=True), primary_key=True, autoincrement=True, comment='项目ID')

    # 设备基本信息
    PrjName: Mapped[Optional[str]] = mapped_column('PrjName', String(45), comment='项目名称', nullable=True)
    PrjCode: Mapped[Optional[str]] = mapped_column('PrjCode', String(100), comment='项目编号', nullable=True)
    PrjType: Mapped[Optional[int]] = mapped_column('PrjType', BigInteger, comment='项目类型', nullable=True)
    PrjDesc: Mapped[Optional[str]] = mapped_column('PrjDesc', String(245), comment='项目描述', nullable=True)
    PrjStatus: Mapped[Optional[str]] = mapped_column('PrjStatus', String(45), comment='项目状态', nullable=True)
    StartDate: Mapped[Optional[datetime]] = mapped_column('StartDate', DateTime, comment='开始日期', nullable=True)
    EndDate: Mapped[Optional[datetime]] = mapped_column('EndDate', DateTime, comment='结束日期',
                                                         nullable=True)
    Manager: Mapped[Optional[str]] = mapped_column('Manager', String(45), comment='项目经理', nullable=True)
    Money: Mapped[Optional[Decimal]] = mapped_column('Money', Numeric, comment='项目资金', nullable=True)

    # 审计字段
    CreateBy: Mapped[Optional[str]] = mapped_column('CreateBy', String(45), comment='创建者', nullable=True)
    CreateTime: Mapped[Optional[datetime]] = mapped_column('CreateTime', DateTime, comment='创建时间',
                                                           nullable=True)
    UpdateBy: Mapped[Optional[str]] = mapped_column('UpdateBy', String(45), comment='更新者', nullable=True)
    UpdateTime: Mapped[Optional[datetime]] = mapped_column('UpdateTime', DateTime, comment='更新时间',
                                                           nullable=True)
    DeleteTime: Mapped[Optional[datetime]] = mapped_column('DeleteTime', DateTime, comment='删除时间',
                                                           nullable=True)
    Remark: Mapped[Optional[str]] = mapped_column('Remark', String(245), comment='备注', nullable=True)