package com.ruoyi.teach.controller;

import com.ruoyi.common.core.controller.TeachBaseController;
import com.ruoyi.common.core.domain.AjaxResult;
import com.ruoyi.teach.domain.entity.Project;
import com.ruoyi.teach.service.IProjectService;
import lombok.RequiredArgsConstructor;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequiredArgsConstructor
@RequestMapping("/ProjectInfo")
public class ProjectController extends TeachBaseController {

    private final IProjectService projectService;

    @GetMapping("/list")
    public AjaxResult list(
            @RequestParam(value = "prjName", required = false) String prjName,
            @RequestParam(value = "prjCode", required = false) String prjCode,
            @RequestParam(value = "manager", required = false) String manager,
            @RequestParam(value = "prjStatus", required = false) String prjStatus,
            @RequestParam(value = "pageNum") Integer pageNum,
            @RequestParam(value = "pageSize") Integer pageSize
    ) {
        startPage(pageNum, pageSize);
        return getPagedData(
                projectService.findByConditions(prjName, prjCode, manager, prjStatus),
                pageNum,
                pageSize
        );
    }

    @GetMapping("/detail")
    public AjaxResult detail(
            @RequestParam(value = "Id") Long id
    ) {
        return success(projectService.findById(id));
    }

    @PostMapping("/add")
    public AjaxResult add(
            @RequestBody Project project
    ) {
        return success(projectService.addProject(project));
    }

    @PostMapping("/update")
    public AjaxResult update(
            @RequestBody Project project
    ) {
        return success(projectService.updateProject(project));
    }

    @PostMapping("/delete")
    public AjaxResult delete(
            @RequestBody List<Long> ids
    ) {
        return success(projectService.deleteProject(ids));
    }

}