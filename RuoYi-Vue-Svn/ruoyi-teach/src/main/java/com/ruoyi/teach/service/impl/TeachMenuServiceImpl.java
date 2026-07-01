package com.ruoyi.teach.service.impl;

import com.ruoyi.teach.domain.dto.vo.TeachLoginVo;
import com.ruoyi.teach.domain.entity.TeachMenuItem;
import com.ruoyi.teach.domain.entity.TeachRoleMenu;
import com.ruoyi.teach.domain.model.TeachMenu;
import com.ruoyi.teach.mapper.TeachMenuItemMapper;
import com.ruoyi.teach.mapper.TeachRoleMenuMapper;
import com.ruoyi.teach.service.ITeachMenuService;
import com.ruoyi.teach.util.MenuUtil;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.Collection;
import java.util.List;
import java.util.Objects;
import java.util.stream.Collectors;

@Service
public class TeachMenuServiceImpl implements ITeachMenuService {

    @Autowired
    private TeachRoleMenuMapper teachRoleMenuMapper;

    @Autowired
    private TeachMenuItemMapper teachMenuItemMapper;

    @Override
    public List<TeachMenu> selectTeachMenuByRoleId(Long roleId) {

        List<TeachRoleMenu> teachRoleMenus = teachRoleMenuMapper.selectTeachRoleMenuListByRoleId(roleId);
        List<Long> menuIds = teachRoleMenus.stream()
                .filter(Objects::nonNull)
                .map(TeachRoleMenu::getMenuId)
                .filter(Objects::nonNull)
                .map(Number::longValue)
                .collect(Collectors.toList());

        List<TeachMenuItem> teachMenuItems = teachMenuItemMapper.selectByMenuIds(menuIds);

        return MenuUtil.constructTreeMenu(teachMenuItems);
    }

    @Override
    public TeachLoginVo selectTeachLoginInfoByRoleId(Long roleId) {
        List<TeachRoleMenu> teachRoleMenus = teachRoleMenuMapper.selectTeachRoleMenuListByRoleId(roleId);
        List<Long> menuIds = teachRoleMenus.stream()
                .filter(Objects::nonNull)
                .map(TeachRoleMenu::getMenuId)
                .filter(Objects::nonNull)
                .map(Number::longValue)
                .collect(Collectors.toList());

        List<TeachMenuItem> teachMenuItems = teachMenuItemMapper.selectByMenuIds(menuIds);

        List<TeachMenu> menus = MenuUtil.constructTreeMenu(teachMenuItems);

        TeachLoginVo teachLoginVo = new TeachLoginVo();
        teachLoginVo.setMenus(menus);
        teachLoginVo.setPermissions(MenuUtil.extractPermissions(teachMenuItems));

        return teachLoginVo;
    }

    @Override
    public TeachLoginVo selectTeachLoginInfoByRoleIds(Collection<Long> roleIds) {
        List<TeachRoleMenu> teachRoleMenus = teachRoleMenuMapper.selectTeachRoleMenuListByRoleIds(roleIds);
        List<Long> menuIds = teachRoleMenus.stream()
                .filter(Objects::nonNull)
                .map(TeachRoleMenu::getMenuId)
                .filter(Objects::nonNull)
                .map(Number::longValue)
                .collect(Collectors.toList());

        List<TeachMenuItem> teachMenuItems = teachMenuItemMapper.selectByMenuIds(menuIds);

        List<TeachMenu> menus = MenuUtil.constructTreeMenu(teachMenuItems);

        TeachLoginVo teachLoginVo = new TeachLoginVo();
        teachLoginVo.setMenus(menus);
        teachLoginVo.setPermissions(MenuUtil.extractPermissions(teachMenuItems));

        return teachLoginVo;
    }
}
