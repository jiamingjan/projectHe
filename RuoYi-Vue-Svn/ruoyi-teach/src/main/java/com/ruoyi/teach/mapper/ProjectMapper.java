package com.ruoyi.teach.mapper;

import com.ruoyi.teach.domain.entity.Project;
import org.apache.ibatis.annotations.Mapper;
import org.apache.ibatis.annotations.Param;

import java.util.List;

@Mapper
public interface ProjectMapper {

    List<Project> findByConditions(
            @Param("prjName") String prjName,
            @Param("prjCode") String prjCode,
            @Param("manager") String manager,
            @Param("prjStatus") String prjStatus
    );

    Project findById(@Param("id") Long id);

    int addProject(Project project);

    int updateProject(Project project);

    int deleteProject(@Param("ids") List<Long> ids);

}