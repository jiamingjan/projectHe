package com.ruoyi;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.ruoyi.teach.domain.model.TeachMenu;
import com.ruoyi.teach.service.ITeachMenuService;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

import java.util.List;

@SpringBootTest
public class MenuTests {

    @Autowired
    private ITeachMenuService teachMenuService;

    @Autowired
    ObjectMapper objectMapper;

    @Test
    void test_menuService_getAdminMenus() throws JsonProcessingException {
        List<TeachMenu> teachMenus = teachMenuService.selectTeachMenuByRoleId(1L);

        System.out.println(objectMapper.writeValueAsString(teachMenus));
    }

}