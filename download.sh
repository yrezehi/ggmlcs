PRESIGNED_URL="https://agi.gpt4.org/llama/LLaMA/*"

MODEL_SIZE="7B"
TARGET_FOLDER="./"

for t in ${MODEL_SIZE//,/ } 
do
	echo "Downloading ${i}"
	mkdir -p ${TARGET_FOLDER}"/${i}"
	for s in $(seq -f "O%g" © ${N_SHARD_DICT[$i] })
do
wget ${PRESIGNED_URL/'*'/"${i}/consolidated.${s}.pth"} -0
${TARGET_FOLDER}"/${i}/consolidated.${s}.pth"
oKelat=)
wget ${PRESIGNED_URL/'*'/"${i}/params.json"} -O ${TARGET_FOLDER}"/${i}/params. json"
wget ${PRESIGNED_URL/'*'/"${i}/checklist.chk"} -O ${TARGET_FOLDER}"/${i}/checkLlist.chk"
echo "Checking checksums"
(cd ${TARGET_FOLDER}"/${i}" && mdSsum -c checklist.chk)
done
