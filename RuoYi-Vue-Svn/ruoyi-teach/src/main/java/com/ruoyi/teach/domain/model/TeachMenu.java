package com.ruoyi.teach.domain.model;

import lombok.Data;

import java.util.Collections;
import java.util.List;

@Data
public class TeachMenu {

    private String name;

    private String path;

    private String redirect = "";

    private String component;

    private Integer sort;

    private Meta meta;

    private List<TeachMenu> children;

    @Data
    public static class Meta {

        private String title;

        private String isLink;

        private Boolean isHide;

        private Boolean isKeepAlive;

        private Boolean isAffix;

        private Boolean isFrame;

        private List<Object> auth = Collections.emptyList();

        private String icon;
    }

}
