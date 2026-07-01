from typing import Optional, Tuple

from sqlalchemy import and_

from db.models.project_info import ProjectInfo
from db import *

class ProjectInfoService:
    @staticmethod
    def list_project_info(
        filters: Optional[dict] = None,
        page_num: int = 1,
        page_size: int = 10
    ) -> Tuple[int, list[ProjectInfo]]:
        with Session(engine) as session:

            base_query = session.query(ProjectInfo)
            sql_filters = []
            
            if filters:
                for key, value in filters.items():
                    if value is None or not hasattr(ProjectInfo, key):
                        continue

                    if isinstance(value, str):
                        sql_filters.append(getattr(ProjectInfo, key).like(f'%{value}%'))
                    else:
                        sql_filters.append(getattr(ProjectInfo, key) == value)

            if sql_filters:
                base_query = base_query.filter(and_(*sql_filters))

            total = base_query.count()

            return total, base_query.offset((page_num - 1) * page_size).limit(page_size).all()

    @staticmethod
    def add(project_info: ProjectInfo) -> Optional[ProjectInfo]:
        """
        添加跌倒设备
        Args:
            project_info: 设备对象
        Returns:
            添加后的设备对象，失败返回None
        """
        with Session(engine) as session:
            try:
                # 确保Id为None（自增主键）
                project_info.Id = None
                if project_info.EndDate == '':
                    project_info.EndDate = None
                if project_info.StartDate == '':
                    project_info.StartDate = None

                # 添加到会话
                session.add(project_info)

                # flush到数据库以获取Id
                session.flush()
                new_id = project_info.Id
                print(f"Flush后获取到Id: {new_id}")

                # 提交事务
                session.commit()

                # 重新查询获取完整对象（避免refresh问题）
                fresh_project = session.query(ProjectInfo).filter(
                    ProjectInfo.Id == new_id
                ).first()

                if fresh_project:
                    print(f"重新查询成功，Id: {fresh_project.Id}")
                    return fresh_project
                else:
                    print("警告：重新查询失败，返回原对象")
                    return project_info

            except Exception as e:
                session.rollback()
                print(f"添加失败: {str(e)}")
                import traceback
                traceback.print_exc()
                return None



    @staticmethod
    def get_by_id(id: int) -> Optional[ProjectInfo]:
        with Session(engine) as session:
            return session.query(ProjectInfo).filter(ProjectInfo.id == id).first()

    @staticmethod
    def get_all_project_info() -> list[ProjectInfo]:
        with Session(engine) as session:
            return session.query(ProjectInfo).all()

    @staticmethod
    def update(project_info: ProjectInfo) -> Optional[ProjectInfo]:
        with Session(engine) as session:
            # 1. ��ѯ���ݿ������м�¼
            existing_project_info = session.query(ProjectInfo).filter(ProjectInfo.Id == project_info.Id).first()
            if not existing_project_info:
                return None

            # 2. �����ֶΣ����� SQLAlchemy �ڲ����ԣ�
            for key, value in project_info.__dict__.items():
                if key.startswith("_"):  # �����ڲ����ԣ��� _sa_instance_state
                    continue
                setattr(existing_project_info, key, value)

            # 3. �ύ����ˢ��
            session.commit()
            session.refresh(existing_project_info)
            return existing_project_info


    @staticmethod
    def delete(Id: int) -> bool:
        with Session(engine) as session:
            project = session.query(ProjectInfo).filter(ProjectInfo.Id == Id).first()
            if not project:
                return False
            session.delete(project)
            session.commit()
            return True
