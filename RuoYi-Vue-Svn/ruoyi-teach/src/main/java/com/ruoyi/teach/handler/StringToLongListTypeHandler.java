package com.ruoyi.teach.handler;

import org.apache.ibatis.type.BaseTypeHandler;
import org.apache.ibatis.type.JdbcType;

import java.sql.CallableStatement;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

public class StringToLongListTypeHandler extends BaseTypeHandler<List<Long>> {

    @Override
    public void setNonNullParameter(PreparedStatement ps, int i, List<Long> parameter, JdbcType jdbcType) throws SQLException {
        StringBuilder sb = new StringBuilder();
        for (Long id : parameter) {
            sb.append(id).append(",");
        }
        // Remove the last comma
        if (sb.length() > 0) {
            sb.setLength(sb.length() - 1);
        }
        ps.setString(i, sb.toString());
    }

    @Override
    public List<Long> getNullableResult(ResultSet rs, String columnName) throws SQLException {
        String value = rs.getString(columnName);
        return convertStringToList(value);
    }

    @Override
    public List<Long> getNullableResult(ResultSet rs, int columnIndex) throws SQLException {
        String value = rs.getString(columnIndex);
        return convertStringToList(value);
    }

    @Override
    public List<Long> getNullableResult(CallableStatement cs, int columnIndex) throws SQLException {
        String value = cs.getString(columnIndex);
        return convertStringToList(value);
    }

    private List<Long> convertStringToList(String value) {
        if (value == null || value.isEmpty()) {
            return null;
        }
        String[] ids = value.split(",");
        return Arrays.stream(ids)
                .map(Long::parseLong)
                .collect(Collectors.toList());
    }

}