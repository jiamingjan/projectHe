package com.ruoyi.teach.service;

import com.ruoyi.teach.domain.entity.Project;

import java.util.List;

public interface IProjectService {

    List<Project> findByConditions(
            String prjName,
            String prjCode,
            String manager,
            String prjStatus
    );

    Project findById(Long id);

    int addProject(Project project);

    int updateProject(Project project);

    int deleteProject(List<Long> ids);

}