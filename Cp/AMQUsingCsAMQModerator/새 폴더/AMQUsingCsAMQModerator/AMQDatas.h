#pragma once
#include "json/json.h"
#include <string>
#include <vector>
#include <map>

#define NAME_OF( name ) ((void) sizeof(typeid(name)), #name)

/// <summary>
/// 변수 명 생셩 규칙이 이상한 이유
/// Json Key과 변수명을 매칭하였음
/// Json Key 값 검색을 변수 명을 이용하기 때문
/// </summary>
namespace ActiveMQCData {
	class IJsonData {
		/// <summary>
		/// string 으로 변환
		/// </summary>
		/// <returns></returns>
		virtual std::string Tostring() = 0;
		/// <summary>
		/// Json 으로 변환
		/// </summary>
		/// <returns></returns>
		virtual Json::Value ToJson() = 0;
	};

	class DataMessage : virtual public IJsonData
	{
	public:
		/// <summary>
		/// 메시지 사양 버전
		/// </summary>
		std::string Version;
		/// <summary>
		/// 메시지 타입
		/// </summary>
		std::string MessageName;
		/// <summary>
		/// 메시지 설명
		/// </summary>
		std::string Description;
		/// <summary>
		/// 수신측 Subject (주소 개념)
		/// </summary>
		std::string ConsumerAddr;
		/// <summary>
		/// 수신 측 DestinationType (0 – Queue, 1 – Topic)
		/// </summary>
		int ConsumerDestinationType;
		/// <summary>
		/// 발신측 Subject
		/// </summary>
		std::string ProducerAddr;
		/// <summary>
		/// 발신 측 DestinationType (0 – Queue, 1 – Topic)
		/// </summary>
		int ProducerDestinationType;
		/// <summary>
		///  트랜잭션 ID
		/// </summary>
		std::string TransID;
		/// <summary>
		/// string 으로 변환
		/// </summary>
		/// <returns></returns>
		virtual std::string Tostring() = 0;
		/// <summary>
		/// Json 으로 변환
		/// </summary>
		/// <returns></returns>
		virtual Json::Value ToJson() = 0;
		/// <summary>
		/// 입력된 메시지를 이용하여 데이터 자동으로 체우는 함수
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		virtual bool MagicSetValue(std::string data) = 0;
		/// <summary>
		/// 입력된 메시지를 이용하여 데이터 자동으로 체우는 함수
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		virtual bool MagicSetValue(Json::Value data) = 0;
	private:
	};

	class DataJudgment : virtual public DataMessage
	{
	public:
		/// <summary>
		/// 공장 정보
		/// </summary>
		std::string FACILITY;
		/// <summary>
		/// 제품 구분
		/// </summary>
		std::string PRODUCT;
		/// <summary>
		/// 설비ID
		/// </summary>
		std::string MACHINE_ID;
		/// <summary>
		/// 공정 /CWLA, CFA, RWGE
		/// </summary>
		std::string PROCESS_CODE;
		/// <summary>
		/// lot ID
		/// </summary>
		std::string LOT_ID;
		/// <summary>
		/// 판넬 ID
		/// </summary>
		std::string PANEL_ID;
		/// <summary>
		/// CWLA / LINER IDCFA
		/// RWGW / 패널 ID - POKET 넘버
		/// </summary>
		std::string MODULE_ID;
		/// <summary>
		/// SYNAPSE_IMAGING
		/// VARO_IMAGE_AI
		/// VARO_VISION_ANOMALY
		/// VARO_DATA_AI
		/// </summary>
		std::string JUDGE_SERVICE_TYPE;
		/// <summary>
		/// IMAGE_AI : DEFECT_NAME
		/// SYNAPSE : SYNAPSE_RULE_INSPECTION, SYNAPSE_GV_EXTRACTION
		/// </summary>
		std::string SUB_JUDGE_SERVICE_TYPE;

		/// <summary>
		/// string 으로 변환
		/// </summary>
		/// <returns></returns>
		virtual std::string Tostring() = 0;
		/// <summary>
		/// Json 으로 변환
		/// </summary>
		/// <returns></returns>
		virtual Json::Value ToJson() = 0;
		/// <summary>
		/// 입력된 메시지를 이용하여 데이터 자동으로 체우는 함수
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		virtual bool MagicSetValue(std::string data) = 0;
		/// <summary>
		/// 입력된 메시지를 이용하여 데이터 자동으로 체우는 함수
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		virtual bool MagicSetValue(Json::Value data) = 0;
	private:
	};

	class DataAIRQ : public DataJudgment
	{
	public:
		std::vector<std::string> IMAGE_PATH_LIST;

		DataAIRQ();
		DataAIRQ(std::string data);
		DataAIRQ(Json::Value data);
		~DataAIRQ();
		/// <summary>
		/// string 으로 변환
		/// </summary>
		/// <returns></returns>
		virtual std::string Tostring();
		/// <summary>
		/// Json 으로 변환
		/// </summary>
		/// <returns></returns>
		virtual Json::Value ToJson();
		/// <summary>
		/// 입력된 메시지를 이용하여 데이터 자동으로 체우는 함수
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		virtual bool MagicSetValue(std::string data);
		/// <summary>
		/// 입력된 메시지를 이용하여 데이터 자동으로 체우는 함수
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		virtual bool MagicSetValue(Json::Value data);
	private:
		Json::Value RESULT_INFO;
	};

	class SYNAPSE_DEFECT_ITEM : public IJsonData
	{
	public:
		std::string DEFECT_CODE;
		std::string DEFECT_NAME;
		std::string CROP_PATH;
		std::string REVIEW_PATH;
		std::string x;
		std::string y;
		std::string width;
		std::string height;

		SYNAPSE_DEFECT_ITEM();
		SYNAPSE_DEFECT_ITEM(std::string defectCode, std::string defectName, std::string cropPath, std::string reviewPath, std::string x, std::string y, std::string width, std::string height);
		~SYNAPSE_DEFECT_ITEM();

		virtual std::string Tostring();
		virtual Json::Value ToJson();
	private:
	};

	class SynapseRuleResult : public IJsonData
	{
	public:
		std::string RAW_IMAGE_PATH;
		std::string MODEL_NAME;
		std::string MODEL_VERSION;

		SynapseRuleResult();
		SynapseRuleResult(std::string rowImagePath, std::string modelName, std::string modelVersion);
		~SynapseRuleResult();

		virtual std::string Tostring();
		virtual Json::Value ToJson();

		bool AddSynapseDefectItem(std::string defectCode, std::string defectName, std::string cropPath, std::string reviewPath, std::string x, std::string y, std::string width, std::string height);
	private:
		std::vector<SYNAPSE_DEFECT_ITEM> SYNAPSE_DEFECT_ITEM_LIST;
	};

	class DataAIRSResultInfo : public IJsonData
	{
	public:
		std::string SynapseProgramVersion;
		std::string Image_Save_ADJ_Root_Path;
		std::string Image_Save_Review_Root_Path;
		std::map<std::string, SynapseRuleResult> SynapseRuleResultList;

		DataAIRSResultInfo();
		DataAIRSResultInfo(std::string synapseProgramVersion, std::string imageSaveADJRootPath, std::string imageSaveReviewRootPath);
		~DataAIRSResultInfo();

		virtual std::string Tostring();
		virtual Json::Value ToJson();

		void AddSynapseRuleResult(std::string key, std::string rowImagePath, std::string modelName, std::string ModelVersion);
		bool AddSynapseDefectItem(std::string key, std::string defectCode, std::string defectName, std::string cropPath, std::string reviewPath, std::string x, std::string y, std::string width, std::string height);

	private:
	};

	class DataAIRS : public DataJudgment
	{
	public:
		std::string JUDGE_PROGRAM_ID;
		std::string RESULT;
		std::string ERROR_CODE;
		std::string ERROR_MESSAGE;
		std::string WORK_START_DATE;
		std::string WORK_TIME;
		std::string WAIT_TIME;
		ActiveMQCData::DataAIRSResultInfo RESULT_INFO;

		DataAIRS();
		DataAIRS(std::string data);
		DataAIRS(Json::Value data);
		DataAIRS(DataAIRQ data);
		DataAIRS(DataAIRQ data, std::string judgeProgramID, std::string result, std::string errorCode, std::string errorMessage, std::string workStartDate, std::string workTime, std::string waitTime);
		~DataAIRS();

		/// <summary>
		/// string 으로 변환
		/// </summary>
		/// <returns></returns>
		virtual std::string Tostring();
		/// <summary>
		/// Json 으로 변환
		/// </summary>
		/// <returns></returns>
		virtual Json::Value ToJson();
		/// <summary>
		/// 입력된 메시지를 이용하여 데이터 자동으로 체우는 함수
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		virtual bool MagicSetValue(std::string data);
		/// <summary>
		/// 입력된 메시지를 이용하여 데이터 자동으로 체우는 함수
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		virtual bool MagicSetValue(Json::Value data);
		bool MagicSetValue(DataAIRQ data);
		bool MagicSetValue(DataAIRQ data, std::string judgeProgramID, std::string result, std::string errorCode, std::string errorMessage, std::string workStartDate, std::string workTime, std::string waitTime);
		void SetIniData(std::string judgeProgramID, std::string result, std::string errorCode, std::string errorMessage, std::string workStartDate, std::string workTime, std::string waitTime);
		void SetResultInfo(ActiveMQCData::DataAIRSResultInfo dataAIRSResultInfo);
	private:
	};

	class JsonAssist {
	public:
		static std::vector<std::string> JsonArrayToStringArray(const Json::Value& jsonArray) {
			std::vector<std::string> stringArray;
			for (Json::ArrayIndex i = 0; i < jsonArray.size(); ++i) {
				if (jsonArray[i].isString()) {
					stringArray.push_back(jsonArray[i].asString());
				}
			}
			return stringArray;
		}

		static Json::Value StringArrayToJsonArray(const std::vector<std::string>& stringArray) {
			Json::Value jsonArray(Json::arrayValue);
			for (const auto& str : stringArray) {
				jsonArray.append(str);
			}
			return jsonArray;
		}

		static std::string ParsingJson(Json::Value data, std::string key) {
			std::string value;
			if (data[key].isNull()) {
				return value;
			}
			value = data[key].asString();
			return value;
		}

		static int ParsingJsonToInt(Json::Value data, std::string key) {
			int value = 0;
			if (data[key].isNull()) {
				return value;
			}
			value = data[key].asInt();
			return value;
		}
	};
}
