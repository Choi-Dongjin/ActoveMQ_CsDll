#include "AMQDatas.h"

ActiveMQCData::DataAIRSResultInfo::DataAIRSResultInfo() {
}

ActiveMQCData::DataAIRSResultInfo::DataAIRSResultInfo(std::string synapseProgramVersion, std::string imageSaveADJRootPath, std::string imageSaveReviewRootPath) : SynapseProgramVersion(synapseProgramVersion), Image_Save_ADJ_Root_Path(imageSaveADJRootPath), Image_Save_Review_Root_Path(imageSaveReviewRootPath) {
}

ActiveMQCData::DataAIRSResultInfo::~DataAIRSResultInfo() {
}

std::string ActiveMQCData::DataAIRSResultInfo::Tostring()
{
	Json::StyledWriter writer;
	std::string value = writer.write(ToJson());
	return value;
}

Json::Value ActiveMQCData::DataAIRSResultInfo::ToJson()
{
	Json::Value value;
	value[NAME_OF(SynapseProgramVersion)] = SynapseProgramVersion;
	value[NAME_OF(Image_Save_ADJ_Root_Path)] = Image_Save_ADJ_Root_Path;
	value[NAME_OF(Image_Save_Review_Root_Path)] = Image_Save_Review_Root_Path;

	Json::Value synapseRuleResultList;
	std::map<std::string, SynapseRuleResult> m;
	for (std::pair<std::string, SynapseRuleResult> item : SynapseRuleResultList) {
		synapseRuleResultList.append(item.second.ToJson());
	}
	value[NAME_OF(SynapseRuleResultList)] = synapseRuleResultList;
	return value;
}

void ActiveMQCData::DataAIRSResultInfo::AddSynapseRuleResult(std::string key, std::string rowImagePath, std::string modelName, std::string ModelVersion) {
	auto iter = SynapseRuleResultList.find(key);
	if (iter != SynapseRuleResultList.end()) {
		//검색된 Key 있음
		iter->second = SynapseRuleResult{ rowImagePath, modelName, ModelVersion }; // 값을 갱신함
	}
	else {
		// 검색된 Key 없음
		SynapseRuleResultList.insert(std::make_pair(key, SynapseRuleResult{ rowImagePath, modelName, ModelVersion }));
	}
}

bool ActiveMQCData::DataAIRSResultInfo::AddSynapseDefectItem(std::string key, std::string defectCode, std::string defectName, std::string cropPath, std::string reviewPath, std::string x, std::string y, std::string width, std::string height) {
	auto iter = SynapseRuleResultList.find(key);
	if (iter != SynapseRuleResultList.end()) {
		//검색된 Key 있음
		SynapseRuleResultList[key].AddSynapseDefectItem(defectCode, defectName, cropPath, reviewPath, x, y, width, height);
		return true;
	}
	else {
		// 검색된 Key 없음
		return false;
	}
}