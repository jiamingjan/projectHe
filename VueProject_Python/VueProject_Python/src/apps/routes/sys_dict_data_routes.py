# routes/dept_routes.py
from flask import request, jsonify
from typing import Optional

from apps import DDetBlueprint
from db.services.sys_dict_data_service import SysDictDataService

# 创建蓝图，对应 C# 的 DeptController
sys_dict_data_bp = DDetBlueprint('sys_dict_data', __name__, url_prefix='/system/dict/data')


@sys_dict_data_bp.route('/type', methods=['GET'])
def get_dicts():
    """
    获取部门树（对应 C# 的 deptTree 方法）
    返回完整的部门树结构
    """
    try:
        # 调用 service 获取部门树
        dict_type = request.args.get('dictType')
        result = SysDictDataService.get_dicts(dict_type)
        return jsonify(result)
    except Exception as e:
        return jsonify({
            'code': 500,
            'msg': f'获取数据字典失败: {str(e)}',
            'data': []
        })
