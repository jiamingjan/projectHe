package com.ruoyi.teach.service;

import com.ruoyi.teach.domain.dto.vo.TeachLoginVo;
import com.ruoyi.teach.domain.model.TeachMenu;

import java.util.Collection;
import java.util.List;

public interface ITeachMenuService {

    List<TeachMenu> selectTeachMenuByRoleId(Long roleId);

    TeachLoginVo selectTeachLoginInfoByRoleId(Long roleId);

    TeachLoginVo selectTeachLoginInfoByRoleIds(Collection<Long> roleIds);

}
