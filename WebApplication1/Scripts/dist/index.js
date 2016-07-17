webpackJsonp([0],[
/* 0 */
/***/ function(module, exports, __webpack_require__) {

	"use strict";

	Object.defineProperty(exports, "__esModule", {
	    value: true
	});
	exports.renderControl = renderControl;

	var _react = __webpack_require__(1);

	var _react2 = _interopRequireDefault(_react);

	var _reactDom = __webpack_require__(33);

	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

	function renderControl(controlPath, elementId) {
	    (0, _reactDom.render)(_react2.default.createElement(Test, { result: "Passed" }), document.getElementById);
	}

/***/ }
]);