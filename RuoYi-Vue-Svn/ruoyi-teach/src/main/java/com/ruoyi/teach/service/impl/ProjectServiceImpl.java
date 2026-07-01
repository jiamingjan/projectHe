package com.ruoyi.teach.service.impl;

import com.ruoyi.teach.domain.entity.Project;
import com.ruoyi.teach.mapper.ProjectMapper;
import com.ruoyi.teach.service.IProjectService;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
@RequiredArgsConstructor
public class ProjectServiceImpl implements IProjectService {

    private final ProjectMapper projectMapper;

    @Override
    public List<Project> findByConditions(String prjName, String prjCode, String manager, String prjStatus) {
        return projectMapper.findByConditions(prjName, prjCode, manager, prjStatus);
    }

    @Override
    public Project findById(Long id) {
        return projectMapper.findById(id);
    }

    @Override
    public int addProject(Project project) {
        return projectMapper.addProject(project);
    }

    @Override
    public int updateProject(Project project) {
        return projectMapper.updateProject(project);
    }

    @Override
    public int deleteProject(List<Long> ids) {
        return projectMapper.deleteProject(ids);
    }
}