(function (global, factory) {
  if (typeof define === "function" && define.amd) {
    define("vxe-table-plugin-export-pdf", ["exports", "xe-utils"], factory);
  } else if (typeof exports !== "undefined") {
    factory(exports, require("xe-utils"));
  } else {
    var mod = {
      exports: {}
    };
    factory(mod.exports, global.XEUtils);
    global.VXETablePluginExportPDF = mod.exports;
  }
})(typeof globalThis !== "undefined" ? globalThis : typeof self !== "undefined" ? self : this, function (_exports, _xeUtils) {
  "use strict";

  Object.defineProperty(_exports, "__esModule", {
    value: true
  });
  _exports["default"] = _exports.VXETablePluginExportPDF = void 0;
  _xeUtils = _interopRequireDefault(_xeUtils);
  function _interopRequireDefault(e) { return e && e.__esModule ? e : { "default": e }; }
  var globalVxetable;
  var globalJsPDF;
  var globalOptions = {};
  var globalFonts = {};
  function getCellText(cellValue) {
    return cellValue || ' ';
  }
  function getFooterCellValue($xeTable, opts, row, column) {
    var _columnIndex = $xeTable.getVTColumnIndex(column);
    // 兼容老模式
    if (_xeUtils["default"].isArray(row)) {
      return getCellText(row[_columnIndex]);
    }
    return getCellText(_xeUtils["default"].get(row, column.field));
  }
  function getFooterData(opts, footerData) {
    var footerFilterMethod = opts.footerFilterMethod;
    return footerFilterMethod ? footerData.filter(function (items, index) {
      return footerFilterMethod({
        items: items,
        $rowIndex: index
      });
    }) : footerData;
  }
  function exportPDF(params) {
    var _globalVxetable = globalVxetable,
      modal = _globalVxetable.modal,
      t = _globalVxetable.t;
    var fonts = globalOptions.fonts,
      beforeMethod = globalOptions.beforeMethod;
    var $table = params.$table,
      options = params.options,
      columns = params.columns,
      datas = params.datas;
    var props = $table.props;
    var treeConfig = props.treeConfig;
    var _$table$getComputeMap = $table.getComputeMaps(),
      computeColumnOpts = _$table$getComputeMap.computeColumnOpts,
      computeTreeOpts = _$table$getComputeMap.computeTreeOpts;
    var treeOpts = computeTreeOpts.value;
    var columnOpts = computeColumnOpts.value;
    var dX = 7;
    var dY = 15.8;
    var ratio = 3.78;
    var pdfWidth = 210;
    var colWidth = 0;
    var msgKey = 'pdf';
    var showMsg = options.message !== false;
    var type = options.type,
      filename = options.filename,
      isHeader = options.isHeader,
      isFooter = options.isFooter,
      original = options.original;
    var footList = [];
    var headers = columns.map(function (column) {
      var id = column.id,
        field = column.field,
        renderWidth = column.renderWidth;
      var headExportMethod = column.headerExportMethod || columnOpts.headerExportMethod;
      var title = headExportMethod ? headExportMethod({
        column: column,
        options: options,
        $table: $table
      }) : _xeUtils["default"].toValueString(original ? field : column.getTitle());
      var width = renderWidth / ratio;
      colWidth += width;
      return {
        name: id,
        prompt: getCellText(title),
        width: width
      };
    });
    var offsetWidth = (colWidth - Math.floor(pdfWidth + dX * 2 * ratio)) / headers.length;
    headers.forEach(function (column) {
      column.width = column.width - offsetWidth;
    });
    var rowList = datas.map(function (row) {
      var item = {};
      columns.forEach(function (column) {
        item[column.id] = getCellText(treeConfig && column.treeNode ? ' '.repeat(row._level * treeOpts.indent / 8) + row[column.id] : row[column.id]);
      });
      return item;
    });
    if (isFooter) {
      var _$table$getTableData = $table.getTableData(),
        footerData = _$table$getTableData.footerData;
      var footers = getFooterData(options, footerData);
      footers.forEach(function (rows) {
        var item = {};
        columns.forEach(function (column) {
          item[column.id] = getFooterCellValue($table, options, rows, column);
        });
        footList.push(item);
      });
    }
    var fontConf;
    var fontName = options.fontName || globalOptions.fontName;
    if (fonts) {
      if (fontName) {
        fontConf = fonts.find(function (item) {
          return item.fontName === fontName;
        });
      }
      if (!fontConf) {
        fontConf = fonts[0];
      }
    }
    var exportMethod = function exportMethod() {
      /* eslint-disable new-cap */
      var doc = new (globalJsPDF || (window.jspdf ? window.jspdf.jsPDF : window.jsPDF))({
        orientation: 'landscape'
      });
      // 设置字体
      doc.setFontSize(10);
      doc.internal.pageSize.width = pdfWidth;
      if (fontConf) {
        var _fontConf = fontConf,
          _fontName = _fontConf.fontName,
          _fontConf$fontStyle = _fontConf.fontStyle,
          fontStyle = _fontConf$fontStyle === void 0 ? 'normal' : _fontConf$fontStyle;
        if (globalFonts[_fontName]) {
          doc.addFont(_fontName + '.ttf', _fontName, fontStyle);
          doc.setFont(_fontName, fontStyle);
        }
      }
      if (beforeMethod && beforeMethod({
        $pdf: doc,
        $table: $table,
        options: options,
        columns: columns,
        datas: datas
      }) === false) {
        return;
      }
      if (options.sheetName) {
        var title = _xeUtils["default"].toValueString(options.sheetName);
        var textWidth = doc.getTextWidth(title);
        doc.text(title, (pdfWidth - textWidth) / 2, dY / 2 + 2);
      }
      // 转换数据
      doc.table(dX, dY, rowList.concat(footList), headers, {
        printHeaders: isHeader,
        autoSize: false,
        fontSize: 6
      });
      // 导出 pdf
      doc.save("".concat(filename, ".").concat(type));
      if (showMsg && modal) {
        modal.close(msgKey);
        modal.message({
          content: t('vxe.table.expSuccess'),
          status: 'success'
        });
      }
    };
    if (showMsg && modal) {
      modal.message({
        id: msgKey,
        content: t('vxe.table.expLoading'),
        status: 'loading',
        duration: -1
      });
    }
    checkFont(fontConf).then(function () {
      if (showMsg) {
        setTimeout(exportMethod, 1500);
      } else {
        exportMethod();
      }
    });
  }
  function checkFont(fontConf) {
    if (fontConf) {
      var fontName = fontConf.fontName,
        fontUrl = fontConf.fontUrl;
      if (fontUrl && !globalFonts[fontName]) {
        globalFonts[fontName] = new Promise(function (resolve, reject) {
          var fontScript = document.createElement('script');
          fontScript.src = fontUrl;
          fontScript.type = 'text/javascript';
          fontScript.onload = resolve;
          fontScript.onerror = reject;
          document.body.appendChild(fontScript);
        });
        return globalFonts[fontName];
      }
    }
    return Promise.resolve();
  }
  function handleExportEvent(params) {
    if (params.options.type === 'pdf') {
      exportPDF(params);
      return false;
    }
  }
  function pluginSetup(options) {
    Object.assign(globalOptions, options);
  }
  /**
   * 基于 vxe-table 表格的扩展插件，支持导出 pdf 格式
   */
  var VXETablePluginExportPDF = _exports.VXETablePluginExportPDF = {
    config: pluginSetup,
    install: function install(vxetable, options) {
      // 检查版本
      if (!/^(4)\./.test(vxetable.version) && !/v4/i.test(vxetable.v)) {
        console.error('[vxe-table-plugin-export-pdf 4.x] Version vxe-table 4.x is required');
      }
      globalVxetable = vxetable;
      globalJsPDF = options ? options.jsPDF : null;
      var setConfig = vxetable.setConfig || vxetable.config;
      setConfig({
        table: {
          exportConfig: {
            _typeMaps: {
              pdf: 1
            }
          }
        },
        // 兼容老版本
        "export": {
          types: {
            pdf: 1
          }
        }
      });
      vxetable.interceptor.mixin({
        'event.export': handleExportEvent
      });
      if (options) {
        pluginSetup(options);
      }
    }
  };
  if (typeof window !== 'undefined' && window.VXETable && window.VXETable.use) {
    window.VXETable.use(VXETablePluginExportPDF);
  }
  var _default = _exports["default"] = VXETablePluginExportPDF;
});