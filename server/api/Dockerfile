FROM node:22-alpine

# 시스템 기본 설정
WORKDIR /workspace

# package.json만 먼저 복사해서 캐시 최적화
COPY package.json ./

# 의존성 설치
RUN npm install

# 런타임 포트
EXPOSE 3000

CMD ["npm", "run", "dev"]