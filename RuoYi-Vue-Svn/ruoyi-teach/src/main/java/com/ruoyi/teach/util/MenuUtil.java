package com.ruoyi.teach.util;

import com.ruoyi.common.utils.StringUtils;
import com.ruoyi.teach.domain.entity.TeachMenuItem;
import com.ruoyi.teach.domain.model.TeachMenu;
import lombok.NoArgsConstructor;

import java.util.*;
import java.util.stream.Collectors;

@NoArgsConstructor(access = lombok.AccessLevel.PRIVATE)
public class MenuUtil {

    public static Collection<String> extractPermissions(List<TeachMenuItem> menus) {
        return menus.stream()
                .map(TeachMenuItem::getPermission)
                .filter(StringUtils::isNotEmpty)
                .collect(Collectors.toSet());
    }

    public static List<TeachMenu> constructTreeMenu(List<TeachMenuItem> menus) {

        return menus.stream().filter(menu -> menu.getParentId() == 0)
                .map(menu -> convert(menu, menus))
                .sorted(Comparator.comparing(TeachMenu::getSort))
                .collect(Collectors.toList());
    }

    private static TeachMenu convert(TeachMenuItem menuItem, List<TeachMenuItem> menus) {
        TeachMenu menu = new TeachMenu();

        menu.setName(menuItem.getMenuName());
        menu.setPath(menuItem.getPath());
        menu.setComponent(menuItem.getComponent());
        menu.setSort(menuItem.getSort());

        TeachMenu.Meta meta = new TeachMenu.Meta();
        meta.setTitle(menuItem.getMenuName());
        meta.setIsLink(menuItem.getIsLink());
        meta.setIsHide(StringUtils.equals(menuItem.getIsHide(), "1"));
        meta.setIsKeepAlive(StringUtils.equals(menuItem.getIsKeepAlive(), "1"));
        meta.setIsAffix(StringUtils.equals(menuItem.getIsAffix(), "1"));
        meta.setIsFrame(StringUtils.equals(menuItem.getIsFrame(), "1"));
        meta.setIcon(menuItem.getIcon());

        menu.setMeta(meta);

        List<TeachMenu> children = menus.stream().filter(item -> Objects.equals(
                        Optional.ofNullable(item.getParentId()).map(Number::longValue).orElseGet(() -> -1L),
                        menuItem.getMenuId()
                ))
                .map(item -> convert(item, menus.stream().filter(
                        child -> Objects.equals(
                                Optional.ofNullable(child.getParentId()).map(Number::longValue).orElseGet(() -> -1L),
                                item.getMenuId()
                        ) || Objects.equals(child.getMenuId(), menuItem.getMenuId())
                ).collect(Collectors.toList())))
                .sorted(Comparator.comparing(TeachMenu::getSort))
                .collect(Collectors.toList());

        menu.setChildren(children);

        return menu;
    }

}
